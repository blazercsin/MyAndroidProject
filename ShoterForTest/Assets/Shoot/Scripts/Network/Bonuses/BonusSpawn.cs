using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    public GameObject go;
    public float timer ;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (PhotonNetwork.isMasterClient)
                {
                    if (id == 0)
                    {
                        go = PhotonNetwork.Instantiate("Heal", transform.position, transform.rotation, 0) as GameObject;
                    }
                    if (id == 1)
                    {
                        go = PhotonNetwork.Instantiate("Speed", transform.position, transform.rotation, 0) as GameObject;
                    }
                }
                timer = 5;
            }
        }
    }
}
