using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInGrass : MonoBehaviour
{
    public bool hide;
    public SkinnedMeshRenderer body;
    public MeshRenderer[] skins;
    public PhotonView phe;
    // Start is called before the first frame update
    void Start()
    {
        phe = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hide)
        {
            if (!phe.isMine)
            {
                body.enabled = false;
                for (int i = 0; i < skins.Length; i++)
                {
                    skins[i].enabled = false;
                }
            }
        }
        else
        {
            body.enabled = true;
            for (int i = 0; i < skins.Length; i++)
            {
                skins[i].enabled = true;
            }
        }
        
    }
}
