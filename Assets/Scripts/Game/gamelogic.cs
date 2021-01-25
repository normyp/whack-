using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;


public class gamelogic : MonoBehaviour {

    public List<GameObject> moles = new List<GameObject>();
    
    public float timer = 0.0f;
    public float m_timer = 0.0f;
    public float randomTime;
    
    public int selectedMole;

    public int score;
    public int oldMole;

    bool spawned = false;
    private bool beingHandled = false;
    public bool spawning = false;

    GameObject other;

    void Start()
    {
        randomTime = Random.Range(4.0f, 6.0f);
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
	void Update () {
        other = moles[selectedMole];
        lives gameMan = GameObject.FindWithTag("gameMan").GetComponent<lives>();
        if (gameMan._lives <= 0)
        {
            //SceneManager.LoadScene("Leaderboard");
        }
        if (other.GetComponent<hit>().whacked == true && !spawning) //If whacked is true
            {
                other.GetComponent<hit>().whacked = false;
                timer = 0.0f;
                
                //Now spawn new mole
                selectedMole = newnumber();
                moles[selectedMole].GetComponent<hit>().poof.SetActive(false);
                spawning = true;
                randomTime = Random.Range(4.0f, 6.0f);
            }
            //Mole missed
	    else if (timer >= 2.0f && !spawning) //If whacked is false
	        {
                moles[selectedMole].SetActive(false);      
                         
                LoseLife();
                selectedMole = newnumber();
                spawning = true;
                timer = 0.0f;
                m_timer = 2.0f;
                randomTime = Random.Range(4.0f, 6.0f);
            }
        if (m_timer >= randomTime)
        {
            moles[selectedMole].SetActive(true);
            m_timer = 0.0f;
            timer = 0.0f;
            spawning = false;
        }

        m_timer += Time.deltaTime;
        timer += Time.deltaTime;
        //Debug.Log("Timer is at: " +  timer);

           
    }

}
