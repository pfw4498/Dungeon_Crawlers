using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	private Transform tm;
	public KeyCode up, down, left, right;
	bool rightleft = true;


	// Use this for initialization
	void Start () {
		tm = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(up)) {
			if(rightleft==true)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y + .7f);
				rightleft=false;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y + .7f);
				rightleft=false;
			}
		} else if(Input.GetKey(down)) {
			if(rightleft==true)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y - .7f);
				rightleft=false;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y - .7f);
				rightleft=false;
			}


		} else if(Input.GetKey(left)) {
			if(rightleft==false)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
				tm.position = new Vector2(tm.parent.position.x -.7f, tm.parent.position.y );
				rightleft=true;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x -.7f, tm.parent.position.y);
				rightleft=true;
			}
			
		} else if(Input.GetKey(right)) {
			if(rightleft==false)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
				tm.position = new Vector2(tm.parent.position.x + .7f, tm.parent.position.y);
				rightleft=true;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x + .7f, tm.parent.position.y);
				rightleft=true;
			}
		}
	}
}
