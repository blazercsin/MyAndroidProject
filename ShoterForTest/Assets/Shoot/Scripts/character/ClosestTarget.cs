using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosestTarget : MonoBehaviour
{
    public GameObject[] enemies;

    public GameObject closestTarget;
    // Start is called before the first frame update
    void Start()
    {
      //  GetClosest();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetClosest()
    {
        GetComponent<movement>().shooting = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (closestTarget != null)
        {
            for(int I = 0; I < enemies.Length;I++)
            {
                float fdist = Vector3.Distance(transform.position, enemies[I].transform.position);
                float tdist = Vector3.Distance(transform.position, closestTarget.transform.position);
                if (fdist < tdist)
                {
                    closestTarget = enemies[I];
                  //  enemies[I]
                }
                else
                {
                   enemies[I].GetComponent<TargetMark>().InTarget = false;
                }
              
            }
            float ftdist = Vector3.Distance(transform.position, closestTarget.transform.position);
            if (ftdist < 8)
            {
                closestTarget.GetComponent<TargetMark>().InTarget = true;
            }
        }
        else
        {
            if (enemies.Length > 0)
            {
                closestTarget = GameObject.FindGameObjectWithTag("Enemy");
            }
        }
    }
}
