using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectButton : MonoBehaviour
{
    public Text nameroom;
    public Text countPlayers;
    public string nameoftheroom;
    public string countoftheplayers;


    public void Start()
    {
        nameroom.text = nameoftheroom;
        countPlayers.text = countoftheplayers + "/4";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicksy()
    {
        PhotonNetwork.JoinRoom(nameoftheroom);
    }
    private void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
