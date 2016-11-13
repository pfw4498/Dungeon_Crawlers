using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject aimDevice;
	public GameObject bulletSpawn;
	public GameObject bullet;
	public GameObject shield;
	public GameObject heavybullet;
	public GameObject Die;

	private int health = 10;
	public int mana = 10;
	private const int MAXMANA = 15;
	private const int MANAINCR = 1;
	private const int MAXHEALTH = 15;
	private const int HEALTHINCR = 1;
	private float speed = .1f;
	private const float REGEN = 1f;
	
	private Transform tm;
	
	private KeyCode up, down, left, right, space;
	// Use this for initialization
	void Awake() 
	{
		shield = GameObject.Find ("Shield");
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		space = KeyCode.Space;
		tm = GetComponent<Transform>();
		StartCoroutine("Regen");
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
		if(coll.gameObject.tag =="Enemy")
		{
			health-=1;
			Destroy(coll.gameObject);
	    }
		if (health <= 0) {
			Destroy(Die);
		}
		
	}

	// Update is called once per frame
	void Update() 
	{
		// set shield to active
		if(Input.GetKey(space)) {
	
			shield.gameObject.SetActive(true);
		} else {

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

		Shoot();
	}

	IEnumerator Regen() {
		while(true) {
			yield return new WaitForSeconds(REGEN);
			if(mana < MAXMANA) {
				mana++;
			}
		}
	}

	void Shoot()
	{
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		float angle = Mathf.Atan2(mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;
		//Debug.Log (angle);
		
		aimDevice.transform.rotation = Quaternion.Euler(0, 0, angle);
		
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(mana>=2)
			{

			Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			mana-=2;

			}
		}
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			if(mana>=5)
			{
			Instantiate(heavybullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
			mana -=5;
			
		
	        }
        }
	}

	void OnGUI()
	{
		GUIStyle style=new GUIStyle();

		GUI.Box(new Rect(10,10,200,50), "Health: " + health + "\nMana: " + mana);


	}


}	