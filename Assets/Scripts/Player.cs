using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject aimDevice;
	public GameObject bulletSpawn;
	public GameObject bullet;

	public int health;
	public int mana;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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
