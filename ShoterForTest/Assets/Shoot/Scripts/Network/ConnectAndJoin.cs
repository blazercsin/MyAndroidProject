using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ConnectAndJoin : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    public byte Version = 1;
    public bool rooms;
    public MenuUI mu;
    public RoomInfo[] roomy;
    public string playername;
    public List<string> roomses;
    public Transform sampleroom;
    public GameObject sproom;
    public GameObject canv;
    public NickChanging nc;
    public bool conect;
    void Start()
    {
        PhotonNetwork.autoJoinLobby = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (conect)
        {
            PredJoiun();
            conect = false;
        }
        if (PhotonNetwork.connected && rooms == true)
        {
            GetRoomList();
            rooms = false;
            Debug.Log("Trying to get rooms");
        }
        if (!PhotonNetwork.connected)
        {
            Debug.Log("Trying to connect");

           
            PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
        }
    }
    public void PredJoiun()
    {
        PhotonNetwork.JoinRoom(playername+"'s room");
    }
    public void CreateRoomPublic()
    {
        PhotonNetwork.CreateRoom(nc.nick+"'s room", new RoomOptions() { MaxPlayers = 4 }, null);
    }
    public void CreateRoomPrivate()
    {
        string[] pl = PlayerPrefs.GetString("host").Split(' ');
        PhotonNetwork.CreateRoom("p;"+pl[1], new RoomOptions() { MaxPlayers = 4 }, null);
      //  Debug.Log(pl[1]);

        
       // PhotonNetwork.JoinRoom("p;");
        //roomy = PhotonNetwork.GetRoomList();
        
    }
    public void OnJoinedRoom()
    {
       PhotonNetwork.LoadLevel(1);
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
    }

    public virtual void OnConnectedToMaster()
    {
       
        Debug.Log("Connected!");
     
      
         //PhotonNetwork.JoinRandomRoom();
    }
    void OnJoinedLobby()
    {
        mu.load = true;
        Debug.Log("You in the lobby");
        GetComponent<GetIP>().enabled = true;
       
    }
    public void RemoveRooms()
    {
      //  for(int I = 0; I < roomses.Count; I++)
      //  {
            roomses.RemoveRange(0,roomses.Count);
       // }
    }
    public void GetRoomList()
    {
       

        foreach (RoomInfo game in PhotonNetwork.GetRoomList())
         {
            string[] pr = game.Name.Split(';');
            if (pr[0] != "p")
            {
               // roomses.Remove(game.Name);
                roomses.Add(game.Name+";"+game.PlayerCount);
            }
            else
            {
                Debug.Log("Heres the private room");
            }
        }
        for(int I=0;I< roomses.Count; I++)
        {
            GameObject go = GameObject.Instantiate(sproom, new Vector3(sampleroom.position.x, sampleroom.position.y - (I * 75), sampleroom.position.z),Quaternion.identity) as GameObject;
            string[] mass = roomses[I].Split(';');
            go.GetComponent<ConnectButton>().nameoftheroom = mass[0];
            go.GetComponent<ConnectButton>().countoftheplayers = mass[1];
            go.transform.parent = canv.transform;
            go.transform.position = new Vector2(sampleroom.position.x, go.transform.position.y);
            go.GetComponent<RectTransform>().sizeDelta = sampleroom.GetComponent<RectTransform>().sizeDelta;
        }
    }
    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

}
