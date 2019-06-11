using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInstant : MonoBehaviour
{
    public GameObject pref;
    public float timer = 3;
    public Image Timimg;
    public Text Timertext;
    public bool spawn;
    public SpawnPoints sp;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pref == null&&spawn)
        {
            Timimg.gameObject.SetActive(true);
            if (timer >= 3) {
                Timertext.text = "3";
                    }
            if (timer <= 2)
            {
                Timertext.text = "2";
            }
            if (timer <= 1)
            {
                Timertext.text = "1";
            }
            timer -= Time.deltaTime;
            Timimg.fillAmount = timer / 3;

            if (timer <= 0)
            {
                PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0) ;
                pref = GameObject.FindGameObjectWithTag("Player");
                sp.pl = pref;
                Timimg.gameObject.SetActive(false);
                timer = 3;
                spawn = false;
                sp.trys = true;
            }
        }
        
    }
}
