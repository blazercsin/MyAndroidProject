using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public CamScript cs;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponent<CamScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
          //  cs.mp = target;
            transform.position =Vector3.Lerp(transform.position, target.position + offset,speed);
        }
    }
    public void FireClick()
    {
        if (target != null)
        {
          
            target.GetComponent<ClosestTarget>().GetClosest();
            target.GetComponent<GunController>().Shotgun();
        }
    }
}
