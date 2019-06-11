using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public string dealername;
    public float tim = 0.5f;
    public PhotonView phe;
    // Start is called before the first frame update
    void Start()
    {
        phe = GetComponent<PhotonView>();
        GameObject.Find("Main Camera").GetComponent<CamScript>().Vibro(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        tim -= Time.deltaTime;
        if (tim <= 0)
        {
            if (phe.isMine)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
        
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "grass")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            if (phe.isMine)
            {
                other.GetComponent<PhotonView>().RPC("DMG", PhotonTargets.All, 0.8f, dealername);
            }

           

        }
    }
    }
