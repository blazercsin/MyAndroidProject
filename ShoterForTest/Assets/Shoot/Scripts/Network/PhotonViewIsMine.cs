using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonViewIsMine : MonoBehaviour
{
    public PhotonView phe;
    public movement mov;
    public CharacterController cc;
    public ClosestTarget ct;
    public TargetMark tm;
    // Start is called before the first frame update
    void Start()
    {
        phe = GetComponent<PhotonView>();

        if (!phe.isMine)
        {
            gameObject.tag = "Enemy";
            mov.enabled = false;
           // cc.enabled = false;
            ct.enabled = false;
            tm.enabled = true;
        }
        else
        {
            mov.ss = GameObject.Find("FireButton").GetComponent<ShootStick>();
            mov.MainCam = GameObject.FindGameObjectWithTag("MainCamera");
            mov.MainCam.GetComponent<CameraChar>().target = this.gameObject.transform;
            mov.ts = GameObject.Find("LeftStick").GetComponent<TouchStick>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
