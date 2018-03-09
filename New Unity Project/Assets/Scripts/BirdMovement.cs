using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour 
{
	public float speed = 2;
	public float force = 300;
	private	 float	 inputY = 0f;
	private float inputDelay = 0.75f;
	public float gSpeed = 0.6f;

	private int jumpCount = 0;
	private void GetInput()
	{
		inputY = Input.GetAxisRaw("Jump");
	}

	void Start () 
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}
	
	void Update () 
	{
		GetInput();
	}

	void FixedUpdate()
	{
		if(Mathf.Abs(inputY)> inputDelay)
		{
			if(jumpCount > 0)
			{	
				return;
			}
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
			jumpCount++;
		}
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * -1 * gSpeed);
		jumpCount = 0;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//Application.LoadLevel(Application.loadedLevel);
	}
}
