using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletin : MonoBehaviour
{
    public AudioClip[] ac;
    public PhotonView phe;
    public float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, ac.Length);
        GetComponent<AudioSource>().clip = ac[r];
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (GetComponent<PhotonView>().isMine)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
