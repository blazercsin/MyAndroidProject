using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TouchStick : MonoBehaviour {
	public float horizontal;
	public float vertical;
	public Image joyStick;
	public Vector2 startpos;
	public Vector2 tek_pos;
	public int test;
	public  bool Get;
	public Vector3 max_p;
    public Touch tt;

	// Use this for initialization
	void Start () {

        tek_pos = startpos;
        max_p.x = Screen.width / 3;
		max_p.y = Screen.height / 3;
       
    }


	void Update () {
		startpos.x = Screen.width / 6;
		startpos.y = Screen.height / 6;
		max_p.x = Screen.width / 3;
		max_p.y = Screen.height / 3;

        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Debug.Log("" + Input.touchCount);
           
                tek_pos = Input.touches[0].position;
                tt = Input.touches[0];
            
           
            if (new Rect (0, 0, max_p.x, max_p.y).Contains (tek_pos)) {
					Get = true;
				} else {
                
					if (!Get) {
					horizontal = 0;
					vertical = 0;
						tek_pos = startpos;
					}
				}
			}
        if(Input.GetMouseButtonUp(0) ){
			horizontal = 0;
			vertical = 0;
				tek_pos =startpos;

				Get = false;
			}
			tek_pos.x = Mathf.Clamp (tek_pos.x, 0,max_p.x);
			tek_pos.y = Mathf.Clamp (tek_pos.y, 0, max_p.y);

			joyStick.rectTransform.position = tek_pos;
		if (Get) {
			horizontal = (tek_pos.x / max_p.x) - 0.5f;
			vertical = (tek_pos.y / max_p.y) - 0.5f;
		}
			//horizontal = (tek_pos.x - Screen.width/6) /150;
			//vertical = (tek_pos.y - Screen.height/6) / 70;
		
	}

}
