using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public Renderer mat;
    public float scrollSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
      
        mat = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        mat.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
    }
}
