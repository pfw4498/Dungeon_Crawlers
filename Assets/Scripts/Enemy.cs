using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	//float to reference speed, gameobject to reference itself
	public float speed;
	
	//Vectors for movement
	private Vector3 velocity;
	private Vector3 direction;
	private Vector3 position;

	private Vector3 seekPoint;

	private bool seek;

	public GameObject bulletSpawn;
	public GameObject bullet;
	public Transform player;

	// Use this for initialization
	void Start() 
	{
		//Set the velocity and the direction to 0 and facing right
		velocity = new Vector3(0,0,0);
		direction = new Vector3(1,0,0);
		//Set the position and direction
		position = transform.position;
		direction = transform.rotation * direction;
		seek = true;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(seek == true)
		{
			StartCoroutine("WaitTime");
		}

		if(seek == false)
		{
			Move(seekPoint);
		}

		Bounce();
	}
	
	/// <summary>
	/// Move this instance.
	/// Supposedly moves at an angle, in a straight line
	/// </summary>
	void Move(Vector3 point)
	{
		direction = (direction + point).normalized;

		velocity = speed * direction * Time.deltaTime;
		if(position.x > Camera.main.ViewportToWorldPoint(new Vector3(0.96f,1,0)).x)
		{
			position.x = Camera.main.ViewportToWorldPoint(new Vector3(0.96f,1,0)).x;
			velocity = Vector3.zero;
			seek = false;
		}
		else if(position.x < Camera.main.ViewportToWorldPoint(new Vector3(0.04f,0,0)).x)
		{
			velocity = Vector3.zero;
			position.x = Camera.main.ViewportToWorldPoint(new Vector3(0.04f,0,0)).x;
			seek = false;
		}
		else if(position.y > Camera.main.ViewportToWorldPoint(new Vector3(1,0.96f,0)).y)
		{
			position.y = Camera.main.ViewportToWorldPoint(new Vector3(1,0.96f,0)).y;
			velocity = Vector3.zero;
			seek = false;
		}
		else if(position.y < Camera.main.ViewportToWorldPoint(new Vector3(0,0.04f,0)).y)
		{
			velocity = Vector3.zero;
			position.y = Camera.main.ViewportToWorldPoint(new Vector3(0,0.04f,0)).y;
			seek = false;
		}
		else
		{
			position += velocity;
		}
		gameObject.transform.position = position;
		gameObject.transform.up = direction;
		//Debug.Log("MOVING IS TRUE");
	}

	private Vector3 RandPoint()
	{
		Vector3 point = new Vector3(0,0,0);
		//float X = Random.Range(Camera.main.WorldToViewportPoint(new Vector3(-13,0,0)).x ,Camera.main.WorldToViewportPoint(new Vector3(13,0,0)).x);
		//float Y = Random.Range(Camera.main.WorldToViewportPoint(new Vector3(0,-7,0)).y ,Camera.main.WorldToViewportPoint(new Vector3(0,7,0)).y);
		float X = Random.Range(-13,13);
		float Y = Random.Range(-7,7);

		point.x = X;
		point.y = Y;
		point.z = 0;

		return point;
	}

	private void Bounce()
	{
		if(position.x > Camera.main.ViewportToWorldPoint(new Vector3(0.96f,1,0)).x)
		{
			position.x = Camera.main.ViewportToWorldPoint(new Vector3(0.96f,1,0)).x;
			velocity.x *= -1;
		}
		else if(position.x < Camera.main.ViewportToWorldPoint(new Vector3(0.04f,0,0)).x)
		{
			velocity.x *= -1;
			position.x = Camera.main.ViewportToWorldPoint(new Vector3(0.04f,0,0)).x;
		}
		
		if(position.y > Camera.main.ViewportToWorldPoint(new Vector3(1,0.96f,0)).y)
		{
			position.y = Camera.main.ViewportToWorldPoint(new Vector3(1,0.96f,0)).y;
			velocity.y *= -1;
		}
		else if(position.y < Camera.main.ViewportToWorldPoint(new Vector3(0,0.04f,0)).y)
		{
			velocity.y *= -1;
			position.y = Camera.main.ViewportToWorldPoint(new Vector3(0,0.04f,0)).y;
		}
	}

	IEnumerator WaitTime()
	{
		seek = false;
		yield return new WaitForSeconds(2f);
		//Debug.Log("SEEKING: " + seek);
		seek = true;
		Shoot();
		seekPoint = RandPoint();
		//Debug.Log("seekPoint = " + seekPoint);
	}

	void Shoot()
	{
		float angle = Mathf.Atan2(position.y, GameObject.Find("Player").transform.position.x) * Mathf.Rad2Deg;
		gameObject.transform.rotation = Quaternion.Euler(0,0,angle);
		Instantiate(bullet, bulletSpawn.transform.position, gameObject.transform.rotation);
	}
}
