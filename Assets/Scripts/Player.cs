using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject aimDevice;
	public GameObject bulletSpawn;
	public GameObject bullet;
	public GameObject shield;
	
	public int health;
	public int mana;
	public const int MAXMANA = 15;
	public const int MANAINCR = 1;
	public const int MAXHEALTH = 15;
	public const int HEALTHINCR = 1;
	public float speed = 2f;

	private Transform tm;

	public KeyCode up, down, left, right, space;
	// Use this for initialization
	void Awake () 
	{
		shield.gameObject.SetActive(false);
		tm = GetComponent<Transform>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Health" && health < MAXHEALTH) {
			health += HEALTHINCR;
			Destroy(coll.gameObject);
		}
		if(coll.gameObject.tag == "Mana" && mana < MAXMANA) {
			mana += MANAINCR;
			Destroy(coll.gameObject);
		}
	}
	// Update is called once per frame
	void Update () 
	{
		// set shield to active
		if(Input.GetKey(space)) {
			Debug.Log ("aaa");
			shield.gameObject.SetActive(true);
		} else {
			Debug.Log("ggg");
			shield.gameObject.SetActive(false);
		}

		// general movement
		if(Input.GetKey(up)) {
			tm.Translate(Vector2.up * speed);
		} else if(Input.GetKey(down)) {
			tm.Translate(Vector2.down * speed);
		}
		if(Input.GetKey(left)) {
			tm.Translate(Vector2.left * speed);

		} else if(Input.GetKey(right)) {
			tm.Translate(Vector2.right * speed);
		}
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		float angle = Mathf.Atan2(mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;
		//Debug.Log (angle);
		
		aimDevice.transform.rotation = Quaternion.Euler(0, 0, angle);

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
		}
	}
}
