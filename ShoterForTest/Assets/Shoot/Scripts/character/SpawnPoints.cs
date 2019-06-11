using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject pl;
    public int r;
    public bool trys;
    // Start is called before the first frame update
    void Start()
    {
        trys = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pl == null&&trys)
        {
            RandSpawn();
            trys = false;
        }
    }
    public void RandSpawn()
    {
        r = Random.RandomRange(0, spawnpoints.Length);
        spawnpoints[r].GetComponent<PlayerInstant>().spawn = true;
    }
}
