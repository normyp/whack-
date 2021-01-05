using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class spawner : MonoBehaviour {

    public List<GameObject> moles = new List<GameObject>();

    public List<GameObject> poofs = new List<GameObject>();
    
    public float timer = 0.0f;

    public int selectedMole;

    public int x, y;

    public int score;

    bool spawned = false;

    GameObject other;

    void Start()
    {        
        for(int x = 0; x <= 8; x++)
        {
            //Adds all the spawns to the list
            moles.Add(GameObject.FindGameObjectWithTag("mole")); //FIXME: Make sure the game objects are distinct
            moles[x].SetActive(false);
        }

        for(int x = 0; x <= 8; x++) 
        {
            poofs.Add(GameObject.FindGameObjectWithTag("poof"));
            //poofs[y].SetActive(false);
        }

        if (!spawned) //Whilst nothing has been spawned
            {
                //Spawn moles
                selectedMole = Random.Range(0, 9);
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

	// Update is called once per frame
	void Update () {
        other = moles[selectedMole];

        if (other.GetComponent<hit>().whacked == true) //If whacked is true
            {
                Debug.Log("Spawned a mole");
                other.GetComponent<hit>().whacked = false;
                timer = 0.0f;
                //Now spawn new mole
                selectedMole = Random.Range(0, 9);
                moles[selectedMole].GetComponent<hit>().poof.SetActive(false);
                moles[selectedMole].SetActive(true);
                
            }
            //Mole missed
	    else if (timer >= 2.0f) //If whacked is false
	        {
                moles[selectedMole].SetActive(false);
                int oldMole = selectedMole;
               
                LoseLife();
                selectedMole = Random.Range(0, 9);


            if (selectedMole != oldMole) { 
                moles[selectedMole].SetActive(true);
            }
               
                timer = 0.0f;
	        }
	        timer += Time.deltaTime;
	        //Debug.Log("Timer is at: " +  timer);

           
    }

}
