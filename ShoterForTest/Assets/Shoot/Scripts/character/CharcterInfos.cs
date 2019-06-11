using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharcterInfos : MonoBehaviour  
{
    public string names;
    public float HP;  
    public PhotonView phe;
    public HPBAR hb;
    public float timer = 0.2f;
    public int killcounter = 0;
    private string lastdmgname;
    // Start is called before the first frame update
    void Start()
    {
        phe = GetComponent<PhotonView>();
        hb = GameObject.Find("MyHP").GetComponent<HPBAR>();
        if (phe.isMine)
        {
            names = PlayerPrefs.GetString("nick");
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (phe.isMine)
        {
            if (HP > 100)
            {
                HP = 100;
            }
            hb.bar.fillAmount = HP / 100;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                phe.RPC("NameText", PhotonTargets.All, names);
                timer = 0.2f;
            }
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<HPUI>().mygo.GetComponent<Image>().fillAmount = HP / 100;
        }
        if (HP <= 0)
        {
            Death();
        }
        else
        {
           
        }
    }
    [PunRPC]
    public void AddKill()
    {
        if (phe.isMine)
        {
          
            GameObject.Find("ImageKill").GetComponent<killercounter>().killercount += 1;
        }
    }
    public void Death()
    {
        if (phe.isMine)
        {
            if (lastdmgname != ""&&gameObject.name!= lastdmgname)
            {
                Debug.Log("this guy kill me:" + lastdmgname);
                GameObject.Find(lastdmgname).GetComponent<PhotonView>().RPC("AddKill",PhotonTargets.All);
            }
            PhotonNetwork.Instantiate("Dead", transform.position, transform.rotation,0);
            PhotonNetwork.Destroy(this.gameObject);
           
        }
    }
    [PunRPC]
    public void NameText(string nn)
    {
        gameObject.name = nn;
        names = nn;
    }
    [PunRPC]
    public void DMG(float dm, string names)
    {
        lastdmgname = names;
        HP -= dm;
    }
    [PunRPC]
    public void Heal()
    {
        HP += 40;
    }
}
