using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundS : MonoBehaviour
{
    public bool m;
    public bool s;
    // Start is called before the first frame update
    void Start()
    {
        if (m)
        {
            int ms = PlayerPrefs.GetInt("Music");
            if (ms == 1)
            {
                GetComponent<AudioSource>().volume = 0;
            }
            
        }
        if (s)
        {
            int ss = PlayerPrefs.GetInt("Sound");
            if (ss == 1)
            {
                GetComponent<AudioSource>().volume = 0;
            }
        }

    }

   
}
