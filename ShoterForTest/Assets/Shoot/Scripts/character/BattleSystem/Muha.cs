using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muha : MonoBehaviour
{
    public GameObject ikl;
    public GameObject ikr;
    public GameObject player;
    public Transform Shotpoint;
    public float timer = 1;
    public int force = 250;
    public bool tryshoot;
    public GameObject muzleflash;
    private float timerm = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (tryshoot)
        {
           
            timer -= Time.deltaTime;
            if (timer < 0.6f)
            {
                muzleflash.SetActive(false);
            }
            else
            {
                muzleflash.SetActive(true);
            }
            if (timer <= 0)
            {
                
                timer = 1;
                tryshoot = false;
            }
        }
    }
    public void Shoot()
    {
        if (tryshoot == false)
        {
            GetComponent<Animator>().Play("fire");
           
                GameObject go = PhotonNetwork.Instantiate("Granade", Shotpoint.position, Quaternion.identity, 0) as GameObject;
                go.GetComponent<Granade>().dealname = player.name;
                go.GetComponent<Rigidbody>().AddForce(-transform.forward * force);
            

            Debug.Log("GRANAAADE!!");
            tryshoot = true;
        }
    }
    public void SetIKPoints()
    {
        player.GetComponent<GunController>().ikl = ikl;
        player.GetComponent<GunController>().ikr = ikr;
    }
    public void MUZ()
    {
        tryshoot = true; 
      
    }
}
