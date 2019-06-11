using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public GameObject expl;
    public string dealname;
    public PhotonView phe;
    public float timer = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        phe = GetComponent<PhotonView>();
        if (!phe.isMine)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            phe.RPC("Pose", PhotonTargets.All, transform.position);
            timer = 0.02f;
        }
    }
    [PunRPC]
    public void Pose(Vector3 pos)
    {
        if (!phe.isMine)
        {
            transform.position = pos;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
       
        if (phe.isMine)
        {
            GameObject go = PhotonNetwork.Instantiate("Explosion", transform.position, Quaternion.identity, 0) as GameObject;
            go.GetComponent<Explosion>().dealername = dealname;
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
