using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunTest : MonoBehaviour
{
    public bool bb;
    public GameObject pref;
    public Vector3 ros;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Shot();
        if (bb)
        {
            Shot();
            bb = false;
        }
    }
    public void Shot()
    {
        RaycastHit h;
         for (int I = 0; I < 5; I++)
         {
       
        Vector3 direction = transform.forward;
        Vector3 spread = Vector3.zero;
    //    spread += transform.up * Random.Range(-1f, 1f);
        spread +=transform.right * Random.Range(-2f, 2f); // add random left or right

        // Using random up and right values will lead to a square spray pattern. If we normalize this vector, we'll get the spread direction, but as a circle.
        // Since the radius is always 1 then (after normalization), we need another random call. 
        direction += spread.normalized * Random.Range(0f, 0.2f);
        Ray r = new Ray(transform.position, direction);
           
            if (Physics.Raycast(r, out h))
            {
            Debug.DrawRay(transform.position, direction, Color.green);
           
              pref = GameObject.Instantiate(pref, h.point, Quaternion.identity);
        }
        }
    
        }
}
