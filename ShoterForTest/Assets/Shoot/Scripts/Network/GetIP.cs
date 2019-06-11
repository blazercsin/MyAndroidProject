using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class GetIP : MonoBehaviour
{
    // Start is called before the first frame update
    public string host;
    public bool tr;
    IEnumerator Start()
    {
        using (WWW www = new WWW("http://checkip.dyndns.org"))
        {
            yield return www;
            string[] cleanf = www.text.Split(':');
            string[] cleant = cleanf[1].Split('<');
            host = cleant[0];
            PlayerPrefs.SetString("host", host);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tr)
        {
            Debug.Log(PlayerPrefs.GetString("host"));
            tr = false;
        }
    }
    void CheckIP()
    {
        
          
       
        //   myExtIP = myExtIPWWW.data;
        //  myExtIP = myExtIP.Substring(myExtIP.IndexOf(":") + 1);
        //  myExtIP = myExtIP.Substring(0, myExtIP.IndexOf("<"));
        // print(myExtIP);
    
    }
}
