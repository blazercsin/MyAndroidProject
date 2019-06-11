using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 10;
    public bool bonus;
    public movement mv;
    public GameObject mc;
    void Start()
    {
        mc = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (bonus)
        {
            mc.GetComponent<InGameUI>().speedbar.gameObject.SetActive(true);
            mc.GetComponent<InGameUI>().speedbar.fillAmount = timer / 10;
            timer -= Time.deltaTime;
            mv.speed = 8;
            Debug.Log(" I`m FAST AS FUCK BOI!!!");
            if (timer <= 0)
            {
                mc.GetComponent<InGameUI>().speedbar.gameObject.SetActive(false);
                mv.speed = 5;
                timer = 10;
                bonus = false;
            }
        }
    }
}
