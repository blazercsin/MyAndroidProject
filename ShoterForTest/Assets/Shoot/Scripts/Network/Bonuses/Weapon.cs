using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public int myid;
    public GameObject[] Sounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            Instantiate(Sounds[myid], transform.position, Quaternion.identity);
            other.GetComponent<GunController>().weapon_id = myid;
            other.GetComponent<GunController>().ChangeWeapon();
            if (GetComponent<PhotonView>().isMine)
            {
             
                PhotonNetwork.Destroy(this.gameObject);
            }
            
        }
    }
}
