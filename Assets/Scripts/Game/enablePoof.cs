using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enablepoof : MonoBehaviour
{
    public Animator anim;

    public GameObject mole;

    void Start()
    {
        this.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    public void start_anim()
    {
        mole.SetActive(false);
        this.gameObject.SetActive(true);
        anim.Play("Poof", 0, 0.0f); //play animation once
    }

}
