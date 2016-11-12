using UnityEngine;
using System.Collections;

//Author: Parker Wilson
//This class moves the bullet and destroys it if it's off screen
//Shouldn't be any errors with this class

public class BulletMove : MonoBehaviour 
{
	//float to reference speed, gameobject to reference itself
	public float speed;
	public GameObject me;
	
	//Vectors for movement
	private Vector3 velocity;
	public Vector3 direction;
	private Vector3 position;
	
	// Use this for initialization
	void OnEnable () 
	{
		//Set the velocity and the direction to 0 and facing right
		velocity = new Vector3(0,0,0);
		direction = new Vector3(1,0,0);
		//Set the position and direction
		position = transform.position;
		direction = transform.rotation * direction;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Call move and destroy
		Move();
		Delete();
	}
	
	/// <summary>
	/// Move this instance.
	/// Supposedly moves at an angle, in a straight line
	/// </summary>
	void Move()
	{
		velocity = speed * direction * Time.deltaTime;
		position += velocity;
		transform.position = position;
	}
	
	/// <summary>
	/// Destroy the bullet when it's offscreen
	/// </summary>
	void Delete()
	{
		//These are about the same bounds numbers for the screen size
		if(position.x > 13f || position.y > 7f
		   || position.x < -13f ||
		   position.y < -7f && me.gameObject.activeSelf == true)
		{
			Destroy(gameObject);
			position = Vector3.zero;
		}
		else
		{
			me.gameObject.SetActive(true);
		}
	}
}
