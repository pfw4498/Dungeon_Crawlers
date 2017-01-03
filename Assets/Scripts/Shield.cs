using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	private Transform tm;
	private KeyCode up, down, left, right;


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
			tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y + 1f);
		} else if(Input.GetKey(down)) {
			tm.position = new Vector2(tm.parent.position.x + 0, tm.parent.position.y - 1f);
		} else if(Input.GetKey(right)) {
			tm.position = new Vector2(tm.parent.position.x + 1f, tm.parent.position.y + 0);
		} else if(Input.GetKey(left)) {
			tm.position = new Vector2(tm.parent.position.x - 1f, tm.parent.position.y + 0);
		}
	}
}
