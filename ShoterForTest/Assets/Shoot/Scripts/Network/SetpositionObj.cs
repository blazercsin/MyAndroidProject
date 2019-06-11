using UnityEngine;
using System.Collections;

public class SetpositionObj : MonoBehaviour {
	public bool OnSetPOS = true;
	
	public Vector3 xyz;
	
	public Quaternion rota;
	public float timS;
	public bool OnOf = false;
	private PhotonView ph;
	public float mTims=0.1f;
	void Start(){
		PhotonView phe = GetComponent<PhotonView>();
		if(phe.isMine)OnOf = true;
		else GetComponent<Interpolation>().enabled=true;
		 ph = GetComponent<PhotonView>();
		
	}

	void pos(){
		if(OnSetPOS){
	xyz=transform.position;
		}
		
   rota=transform.rotation;
		
		
	  if (ph.isMine) {
						ph.RPC ("xi", PhotonTargets.Others, xyz, rota);
				}
	
	
	}
		[PunRPC]
	void xi(Vector3 xy, Quaternion rots){
	if(OnSetPOS){xyz=xy;}
rota=rots;
	}
	
void FixedUpdate () {

	
			if(OnOf){
		timS-=Time.deltaTime;
		if(timS<=0){
		pos();
		timS = mTims;
		}
		}
		if(timS<=0){
		if(OnSetPOS){Vector3 lastPos = xyz;
	    transform.position = lastPos;}
			
		Quaternion Rot = rota;
			transform.rotation = Rot;
		}
			
}
	
}