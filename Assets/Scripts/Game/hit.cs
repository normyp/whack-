using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {

    public GameObject moleMan;
    public bool whacked;
    public GameObject poof;
    public float timer = 0.0f;

    void OnMouseDown()
    {
        GameObject moleMan = GameObject.FindWithTag("man");//Creates an instance of mole manager so that the component gamelogic can be used
        gamelogic game = moleMan.GetComponent<gamelogic>(); //Creates an instance of the gamelogic script so that score can be accessed

        //missed = false;
        poof.GetComponent<enablepoof>().start_anim();

        game.score++;
        whacked = true;


        //Need to override default spawn system and just make a new mole
    }
}
