using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	private Transform tm;
	private KeyCode up, down, left, right;
	private bool rightdir = true, leftdir = false, updir = false, downdir = false;


	// Use this for initialization
	void Start () {
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		tm = GetComponent<Transform>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			
			Destroy (coll.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {

		// move shield in a given direction
		if(Input.GetKey(up)) {
			if(updir==false)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y + .7f);
				rightdir = false; leftdir = false; updir = true; downdir = false;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y + .7f);
			}
		} else if(Input.GetKey(down)) {
			if(downdir==false)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y - .7f);
				rightdir = false; leftdir = false; updir = false; downdir = true;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y - .7f);
			}


		} else if(Input.GetKey(left)) {
			if(leftdir==false)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
				tm.position = new Vector2(tm.parent.position.x -.7f, tm.parent.position.y );
				rightdir = false; leftdir = true; updir = false; downdir = false;;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x -.7f, tm.parent.position.y);
			}
			
		} else if(Input.GetKey(right)) {
			if(rightdir==false)
			{
				tm.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
				tm.position = new Vector2(tm.parent.position.x + .7f, tm.parent.position.y);
				rightdir = true; leftdir = false; updir = false; downdir = false;
			}
			else{
				tm.position = new Vector2(tm.parent.position.x + .7f, tm.parent.position.y);
			}
		}
	}
}
