using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeShot : MonoBehaviour
{
    public GameObject pref;
    public float force;
    public bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
           GameObject go =  GameObject.Instantiate(pref, transform.position, Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            shoot = false;

        }
        
    }
}
