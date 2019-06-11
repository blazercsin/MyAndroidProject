using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NickChanging : MonoBehaviour
{
    public string nick;
    public InputField ifs;
    // Start is called before the first frame update
    void Start()
    {

        nick = PlayerPrefs.GetString("nick");
        ifs.text = nick;
        if (nick == null)
        {
            PlayerPrefs.SetString("nick", "Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ifs.text != nick)
        {
            nick = ifs.text;
            PlayerPrefs.SetString("nick", nick);
        }
    }
}
