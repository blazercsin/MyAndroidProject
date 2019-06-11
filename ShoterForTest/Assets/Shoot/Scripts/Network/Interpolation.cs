using UnityEngine;
using System.Collections;

public class Interpolation : MonoBehaviour {

	public bool OnOf=true;
	public float i = 5;
	private PhotonView phe;

Vector3 lastPos;
Quaternion lRot;
	private float timer=5;
	void Start(){
		timer=2;
		 phe = GetComponent<PhotonView>();
		
	}

void FixedUpdate ()
{
		if(!phe.isMine){OnOf = true;}
	
		if(OnOf){
			if(timer>0){timer-=Time.deltaTime;lastPos=transform.position;}
			else{
transform.position = Vector3.Slerp(lastPos, transform.position, Time.deltaTime * i);
lastPos = transform.position;
			
transform.rotation = Quaternion.Slerp(lRot, transform.rotation,Time.deltaTime * i);

lRot = transform.rotation;
		}
		}
}
}