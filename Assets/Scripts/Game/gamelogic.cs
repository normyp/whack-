using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gamelogic : MonoBehaviour {

    public List<GameObject> moles = new List<GameObject>();
    public GameObject countdownScreen;
    public GameObject easybutton;
    public GameObject medbutton;
    public GameObject hardbutton;
    public GameObject lives;
    public float timer;
    public float despawn_timer;
    public float game_timer;
    public float countdown;
    public float randomDespawnTime;
    public float randomAliveTime;
    public float minAliveTime;
    public float maxAliveTime;
    public float minDespawnTime;
    public float maxDespawnTime;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
    public int selectedMole;

    public int score;
    public int oldMole;

    private bool difficultySelected;
    bool spawned = false;
    private bool newgame;
    private bool beingHandled = false;

    bool firsttime;
    public bool spawning = false;

    public AudioSource audio;
    GameObject other;

    void Start()
    {
        difficultySelected = false;
        firsttime = true;
        countdown = 3.0f;
        game_timer = 0.0f;
        minAliveTime = 0.75f; //ATM timer = 5.0 and despawntimer = 9.0f
        maxAliveTime = 1.25f;
        minDespawnTime = 1.25f;
        maxDespawnTime = 2.75f;
        randomDespawnTime = Random.Range(minDespawnTime, maxDespawnTime);
        randomAliveTime = Random.Range(minAliveTime, maxAliveTime);

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        
        for(int x = 0; x <= 8; x++)
        {
            //Adds all the spawns to the list
            moles.Add(GameObject.FindGameObjectWithTag("mole")); //FIXME: Make sure the game objects are distinct
            moles[x].SetActive(false);
        }

        if (!spawned) //Whilst nothing has been spawned
            {
                //Spawn moles
                selectedMole = newnumber();
                //Debug.Log("Selected mole is " + selectedMole); 
                moles[selectedMole].SetActive(true);
                //poofs[selectedMole].SetActive(true);
                spawned = true;
            }
    }


    void LoseLife()
    {
        GameObject gameMan = GameObject.FindWithTag("gameMan"); //Creates an instance of game manager so that the component lives can be used
        lives player = gameMan.GetComponent<lives>(); //Creates an instance of the lives script so that lives can be accessed
        
        player._lives--; 
    }

    private int newnumber()
    {
        oldMole = selectedMole;
        while(oldMole == selectedMole){
            selectedMole = Random.Range(0, 9);
        }
        return selectedMole;
    }

    private IEnumerator DelaySpawn()
    {
        beingHandled = true;
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Waiting...");
        beingHandled = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if (!difficultySelected)
        {
            if (GameObject.Find("Easy button").GetComponent<difficultyButton>().m_difficulty == "Easy")
            {
                difficultySelected = true;
                minAliveTime = 4.0f; //ATM timer = 5.0 and despawntimer = 9.0f
                maxAliveTime = 5.5f;
                minDespawnTime = 5.5f;
                maxDespawnTime = 6.0f;
                GameObject.Find("Easy button").SetActive(false);
                GameObject.Find("Medium button").SetActive(false);
                GameObject.Find("Hard button").SetActive(false);
            }

            else if (GameObject.Find("Medium button").GetComponent<difficultyButton>().m_difficulty == "Medium")
            {
                difficultySelected = true;
                minAliveTime = 2.0f; //ATM timer = 5.0 and despawntimer = 9.0f
                maxAliveTime = 3.0f;
                minDespawnTime = 3.0f;
                maxDespawnTime = 4.0f;
                GameObject.Find("Easy button").SetActive(false);
                GameObject.Find("Medium button").SetActive(false);
                GameObject.Find("Hard button").SetActive(false);
            }

            else if (GameObject.Find("Hard button").GetComponent<difficultyButton>().m_difficulty == "Hard")
            {
                difficultySelected = true;
                minAliveTime = 0.75f; //ATM timer = 5.0 and despawntimer = 9.0f
                maxAliveTime = 1.25f;
                minDespawnTime = 1.25f;
                maxDespawnTime = 2.75f;
                GameObject.Find("Easy button").SetActive(false);
                GameObject.Find("Medium button").SetActive(false);
                GameObject.Find("Hard button").SetActive(false);
            }
        }

        if(difficultySelected)
    {
        if (countdown <= 0.0f)
        {
            if(firsttime){
                firsttime = false;
                lives.SetActive(true);
                countdownScreen.SetActive(false);
                GameObject.Find("countdown").SetActive(false);
                other = moles[selectedMole];    
            }

            lives gameMan = GameObject.FindWithTag("gameMan").GetComponent<lives>();
            if (gameMan._lives <= 0)
            {
                SceneManager.LoadScene("Leaderboard");
                
            }
            other = moles[selectedMole];    
            if (other.GetComponent<hit>().whacked == true && !spawning) //If whacked is true
            {
                spawning = true;
                other.GetComponent<hit>().whacked = false;
                timer = 0.0f;
                despawn_timer = randomAliveTime;

                audio.Play();
                //Now spawn new mole
                selectedMole = newnumber();
                moles[selectedMole].GetComponent<hit>().poof.SetActive(false);
                
                randomDespawnTime = Random.Range(minDespawnTime, maxDespawnTime);
                randomAliveTime = Random.Range(minAliveTime, maxAliveTime);
            }
            //Mole missed
            else if (timer >= randomAliveTime && !spawning) //If whacked is false
            {
                moles[selectedMole].SetActive(false);

                LoseLife();
                selectedMole = newnumber();
                spawning = true;
                timer = 0.0f;
                despawn_timer = randomAliveTime;
                randomDespawnTime = Random.Range(minDespawnTime, maxDespawnTime);
                randomAliveTime = Random.Range(minAliveTime, maxAliveTime);
            }

            else if (despawn_timer >= randomDespawnTime && spawning)
            {
                selectedMole = newnumber();
                moles[selectedMole].SetActive(true);

                timer = 0.0f;
                despawn_timer = randomAliveTime;
                spawning = false;
            }

            if (game_timer >= 5.0f)
            {
                minAliveTime = 0.75f;
                maxAliveTime = 1.0f;
                minDespawnTime = 1.0f;
                maxDespawnTime = 2.25f;
            }

            if (game_timer >= 10.0f)
            {
                minAliveTime = 0.75f;
                maxAliveTime = 0.95f;
                minDespawnTime = 0.95f;
                maxDespawnTime = 2.25f;
            }

            //game_timer += Time.deltaTime;
            despawn_timer += Time.deltaTime;
            timer += Time.deltaTime;
            //Debug.Log("Timer is at: " +  timer);
        }
        else
        {
            float newNum;
            newNum = Mathf.Round(countdown);
            GameObject.Find("countdown").GetComponent<Text>().text = newNum.ToString();
            
            countdownScreen.SetActive(true);
            countdown -= Time.deltaTime;
        }

    }
    else
    {
        easybutton.SetActive(true);
        medbutton.SetActive(true);
        hardbutton.SetActive(true);
        countdownScreen.SetActive(true);
    }
    }

}
