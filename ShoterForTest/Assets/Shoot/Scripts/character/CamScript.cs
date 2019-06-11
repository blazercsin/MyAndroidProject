using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CamScript : MonoBehaviour {
    public float vobrTim;
	public float tim_speed=0.4f;
	public Vector3 spos;
	
	// Use this for initialization
	void Start () {
		spos = transform.position;
	}

	public void Vibro(float d){
		vobrTim = d;
	}
	
	// Update is called once per frame
	void Update () {
		if (vobrTim > 0) {
			vobrTim-=Time.deltaTime*tim_speed;
			transform.position+=new Vector3(Random.Range(-vobrTim,vobrTim),0,Random.Range(-vobrTim,vobrTim));
		}
		
		}
}
