using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatioSync : MonoBehaviour
{
    public PhotonView phe;
    public float timer = 0.1f;
    public AnimControl ac;
    public movement mov;
    // Start is called before the first frame update
    void Start()
    {
        phe = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phe.isMine)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                phe.RPC("RPCAnum", PhotonTargets.All, mov.isMove);
                timer = 0.1f;
            }
        }
        
    }
    [PunRPC]
    public void RPCAnum(bool an)
    {
        ac.Move(an);
    }
}
