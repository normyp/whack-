using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enablePoof : MonoBehaviour
{
    public Animator anim;

    public GameObject mole;

    void Start()
    {
        this.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update

    public void start_anim()
    {
        mole.SetActive(false);
        this.gameObject.SetActive(true);
        Debug.Log("Poofed");
        anim.Play("Poof", 0, 0.0f); //play animation once
        //Thread.Sleep(5000);
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
