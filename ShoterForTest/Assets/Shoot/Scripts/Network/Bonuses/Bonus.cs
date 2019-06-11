using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public PhotonView phe;
    public int id;
    public GameObject[] Sounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"||other.tag == "Enemy")
        {
            Instantiate(Sounds[id], transform.position, Quaternion.identity);
            if (id == 0)
                {
               
                if (phe.isMine)
                {
                    other.GetComponent<PhotonView>().RPC("Heal", PhotonTargets.All);
                    PhotonNetwork.Destroy(this.gameObject);
                }
                }
                if(id == 1)
                {
                if (other.GetComponent<PhotonView>().isMine)
                {
                    other.GetComponent<BonusSpeed>().bonus = true;
                    other.GetComponent<BonusSpeed>().timer = 10;


                }
                if (phe.isMine)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
                }
            
        }
    }
}
