using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
  
{
    public PhotonView phe;
    // Start is called before the first frame update
    void Start()
    {
    phe = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
 void GetPosition()
{

}
}
