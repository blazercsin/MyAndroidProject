using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public GameObject[] closes;
    public bool music=true;
    public bool sound=true;
    public GameObject mus;
  
    // Start is called before the first frame update
    void Start()
    {
        int m = PlayerPrefs.GetInt("Music");
        int s = PlayerPrefs.GetInt("Sound");
        Debug.Log(m + "MUSIC");
        Debug.Log(s + "Sound");
        if (m == 0)
        {
            music = true;
        }
        else
        {
            music = false;
        }
        if (s == 0)
        {
            sound = true;
        }
        else
        {
            sound = false;
        }
        if (music == false)
        {
            closes[0].SetActive(true);
        }
        else
        {
            closes[0].SetActive(false);
        }
        if (sound == false)
        {
            closes[1].SetActive(true);
        }
        else
        {
            closes[1].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOfMusic()
    {
        music = !music;
        if (music == false)
        {
            closes[0].SetActive(true);
            PlayerPrefs.SetInt("Music", 1);
            mus.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            closes[0].SetActive(false);
            mus.GetComponent<AudioSource>().volume = 0.5f;
        }
       
    }
    public void OnOfSound()
    {
        sound = !sound;
        if (sound == false)
        {

            closes[1].SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);
            
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            closes[1].SetActive(false);
        }
    }

}
