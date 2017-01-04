using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public Player player;
	private Transform tm;
	private KeyCode up, down, left, right;
	private bool updir = false, downdir = false, leftdir = false, rightdir = true;


	// Use this for initialization
	void Start () {
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		tm = GetComponent<Transform>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag =="Enemy") {
			Debug.Log("Collision");
			Destroy (coll.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {

		// move shield in a given direction
		if(Input.GetKey(up)) {
			if(downdir) {
				tm.Rotate(0, 0, 180);
			} else if(leftdir) {
				tm.Rotate(0, 0, -90);
			} else if(rightdir) {
				tm.Rotate(0, 0, 90);
			}
			updir = true; downdir = false; leftdir = false; rightdir = false;
			tm.position = new Vector2(player.transform.position.x + 0, player.transform.position.y + 1f);
		} else if(Input.GetKey(down)) {
			if(updir) {
				tm.Rotate(0, 0, 180);
			} else if(leftdir) {
				tm.Rotate(0, 0, 90);
			} else if(rightdir) {
				tm.Rotate(0, 0, -90);
			}
			updir = false; downdir = true; leftdir = false; rightdir = false;
			tm.position = new Vector2(player.transform.position.x + 0, player.transform.position.y - 1f);
		} else if(Input.GetKey(right)) {
			if(updir) {
				tm.Rotate(0, 0, -90);
			} else if(downdir) {
				tm.Rotate(0, 0, 90);
			} else if(leftdir) {
				tm.Rotate(0, 0, 180);
			}
			updir = false; downdir = false; leftdir = false; rightdir = true;
			tm.position = new Vector2(player.transform.position.x + 1f, player.transform.position.y + 0);
		} else if(Input.GetKey(left)) {
			if(updir) {
				tm.Rotate(0, 0, 90);
			} else if(downdir) {
				tm.Rotate(0, 0, -90);
			} else if(rightdir) {
				tm.Rotate(0, 0, 180);
			}
			updir = false; downdir = false; leftdir = true; rightdir = false;
			tm.position = new Vector2(player.transform.position.x - 1f, player.transform.position.y + 0);
		}
	}
}
