using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int ammo;
    public float dmg;
    public float dist;
    public float reloadingtime;
    public GameObject shootpoint;
    public Transform player;
    public PhotonView phe;
    public GameObject pref;
    public GameObject ikl;
    public GameObject ikr;
    public GameObject muzleflash;
    private float timer = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        phe = player.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (muzleflash.active == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0.2f;
                muzleflash.SetActive(false);
            }
        }
    }
    public void Shoot()
    {

        RaycastHit h;
        for (int I = 0; I < 5; I++)
        {

            Vector3 direction = player.transform.forward;
            Vector3 spread = Vector3.zero;
            spread += player.transform.right * Random.Range(-2f, 2f);
            direction += spread.normalized * Random.Range(0f, 0.2f);
            Ray r = new Ray(shootpoint.transform.position, direction);

            if (Physics.Raycast(r, out h))
            {
               
                if (h.collider.tag == "Enemy")
                {

                    if (phe.isMine)
                    {
                        float distr = Vector3.Distance(player.position, h.point);
                        if (distr < dist)
                        {
                            PhotonNetwork.Instantiate("BloodHit", h.point, Quaternion.identity, 0);
                            h.collider.GetComponent<PhotonView>().RPC("DMG", PhotonTargets.All, dmg, player.gameObject.name);
                        }
                    }



                }
                else
                {
                    PhotonNetwork.Instantiate("BulletHole", h.point, Quaternion.identity, 0);
                }
            }
        }

    }
    public void SetIKPoints()
    {
        player.GetComponent<GunController>().ikl = ikl;
        player.GetComponent<GunController>().ikr = ikr;
    }
    public void MUZ()
    {
        muzleflash.SetActive(true);
    }
}
