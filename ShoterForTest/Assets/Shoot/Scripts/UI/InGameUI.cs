using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameUI : MonoBehaviour
{
    public GameObject munpanel;
    public HPUI hpu;
    public Image speedbar;
    public bool opcl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hpu.target == null)
        {
            speedbar.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("BACK");
            opcl = !opcl;
            OpenPanel();
        }
    }
    public void OpenPanel()
    {
        munpanel.SetActive(opcl);
    }
    public void CloseButtonMenu()
    {
        opcl = false;
        OpenPanel();
    }
    public void ExitMenu()
    {
        PhotonNetwork.Disconnect();
        Application.LoadLevel(0);
    }

}
