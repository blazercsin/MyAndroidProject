using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMark : MonoBehaviour
{
    public bool InTarget;
    public GameObject targmar;
    public GameObject MainCameraa;
    // Start is called before the first frame update
    void Start()
    {
        MainCameraa = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (InTarget)
        {
            MainCameraa.GetComponent<HPUI>().target = this.transform;
            targmar.SetActive(true);
        }
        else
        {

            targmar.SetActive(false);
        }
    }
}
