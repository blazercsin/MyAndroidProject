using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HPUI : MonoBehaviour
{
    public Transform target;
    public Transform cam;
    public Transform mygo;
    public Text enemynme;
    public Vector3 _screenpos;
    public Vector3 startpos;
    public Text myIPText;


    // Use this for initialization
    void Start()
    {
        startpos = mygo.position;
        myIPText.text = PlayerPrefs.GetString("host");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            mygo.position = startpos;
        }
        else
        {
            enemynme.text = target.name;
            _screenpos = cam.GetComponent<Camera>().WorldToScreenPoint(new Vector3(target.position.x,target.position.y+2,target.position.z));
            mygo.position = _screenpos;

        }

    }
}
