using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject GamesPanel;
    public GameObject createPanel;
    public GameObject connectPanel;
    public GameObject panelka;
    public GameObject background;
    public Text context;
    public ConnectAndJoin caj;
    public InputField ip;
    public bool load;
    private float timer = 4;
    public GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (load == true)
        {
            if (timer < 1)
            {
                context.text = "Connected!";
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
              
                  
                
                loadPanel.SetActive(false);
                GamesPanel.SetActive(true);
                load = false;
            }
        }
    }
    public void StartClick()
    {
        createPanel.SetActive(true);
        GamesPanel.SetActive(false);
    }
    public void ConnectToPrivateGame()
    {
        PhotonNetwork.JoinRoom("p;" + ip.text);
    }
    public void CloseCreate()
    {
        createPanel.SetActive(false);
        GamesPanel.SetActive(true);
    }
    public void JoinClic()
    {
        caj.RemoveRooms();
        caj.rooms = true;
        connectPanel.SetActive(true);
        GamesPanel.SetActive(false);
    }
    public void CloseConn()
    {
        connectPanel.SetActive(false);
        GamesPanel.SetActive(true);
    }
    public void MenuOpenPanel() {
        panelka.SetActive(true);
        background.SetActive(true);
            }
    public void SoundShot()
    {
        go.GetComponent<AudioSource>().Play();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
