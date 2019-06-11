using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassshake : MonoBehaviour
{
    public Quaternion Rot;
    public Quaternion startrot;

    void Awake()
    {
        startrot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Rot.z += Time.deltaTime*0.02f;

        transform.rotation = Rot;
       
    }
}
