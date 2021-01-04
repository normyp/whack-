using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {

    public GameObject moleMan;
    public bool whacked;
    public GameObject poof;
    public float timer = 0.0f;

    void OnMouseDown()
    {
        GameObject moleMan = GameObject.FindWithTag("man");//Creates an instance of mole manager so that the component spawner can be used
        spawner spawn = moleMan.GetComponent<spawner>(); //Creates an instance of the spawner script so that score can be accessed

        //missed = false;
        poof.GetComponent<enablePoof>().start_anim();

        //gameObject.SetActive(false);
        spawn.score++;
        whacked = true;


        //Need to override default spawn system and just make a new mole
    }
}
