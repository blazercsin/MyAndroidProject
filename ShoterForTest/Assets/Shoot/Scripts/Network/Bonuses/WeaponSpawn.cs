using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject go;
    public float timer;
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
                    go = PhotonNetwork.Instantiate("Weapon"+id, transform.position, Quaternion.identity, 0) as GameObject;
                }
                timer = 10;
            }
        }
    }
}
