using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun Guns;
    public GameObject[] MyGuns;
    public int weapon_id =0;
    public bool change;
    public IKArms ika;
    public GameObject ikl;
    public GameObject ikr;
    public PhotonView phe;
    public float timer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            phe.RPC("WeaponNetID", PhotonTargets.All, weapon_id);
            timer = 0.1f;
        }
        if (change)
        {
            ChangeWeapon();
            change = false;
        }
    }
    public void Shotgun()
    {
        MyGuns[weapon_id].SendMessage("Shoot");
        if (phe.isMine)
        {
            phe.RPC("Muzzle", PhotonTargets.All);
        }
        //Guns.Shoot();
    }
    public void ChangeWeapon()
    {

        for(int I = 0; I < MyGuns.Length; I++)
        {
            MyGuns[I].SetActive(false);
        }
        MyGuns[weapon_id].SetActive(true);
        SetIKPoints();
    }
    public void SetIKPoints()
    {
        MyGuns[weapon_id].SendMessage("SetIKPoints");
        ika.leftHandObj= ikl.transform;
        ika.rightHandObj = ikr.transform;
    }
    [PunRPC]
    public void WeaponNetID(int id)
    {
        if (weapon_id != id)
        {
           
            if (!phe.isMine)
            {
                weapon_id = id;
                change = true;
            }
        }
    }
    [PunRPC]
    public void Muzzle()
    {
        MyGuns[weapon_id].SendMessage("MUZ");
    }
}
