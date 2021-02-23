using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
{
    public GameObject countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown.transform.position = new Vector3(Screen.width / 2+30, Screen.height/2,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
