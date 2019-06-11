using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBAR : MonoBehaviour
{
    public Image bar;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
               // target = GameObject.FindGameObjectWithTag("Player") as GameObject;
                 
                

            }
        }
    }
}
