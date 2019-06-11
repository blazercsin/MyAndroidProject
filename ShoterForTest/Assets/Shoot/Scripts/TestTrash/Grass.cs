using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "expl")
        {
            Debug.Log("DESTR!!");
        }
        if (other.tag == "Player"||other.tag=="Enemy")
        {
            Debug.Log("TAAG" + other.tag+ other.gameObject.name);
            other.gameObject.GetComponent<HideInGrass>().hide = true;
            Debug.Log("InGrass");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            other.gameObject.GetComponent<HideInGrass>().hide = false;
            Debug.Log("OutGrass");
        }
    }
}
