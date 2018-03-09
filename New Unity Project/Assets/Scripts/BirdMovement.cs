using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour 
{
	public float speed = 2;
	public float force = 300;
	public float speedX = 3;
	
	private float inputX = 0f;
	private	 float	 inputY = 0f;

	private float inputDelay = 0.2f;

	private int jumpCount = 0;
	private void GetInput()
	{
		inputX = Input.GetAxisRaw("Horizontal");
		inputY = Input.GetAxisRaw("Jump");
	}

	void Start () 
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}
	
	void Update () 
	{
		GetInput();
		/*
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
		}
		*/GetComponent<Rigidbody2D>().AddForce(-Vector2.up * force);
	}

	void FixedUpdate()
	{
		// if( Mathf.Abs(inputX) > inputDelay)
		// {
		// 	GetComponent<Rigidbody2D>().velocity = Vector2.right * inputX * speedX;
		// }
		if(Mathf.Abs(inputY)> inputDelay)
		{
			if(jumpCount > 0)
			{	
				jumpCount = 0;
				return;
			}
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
			jumpCount++;
		}	
		// GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//Application.LoadLevel(Application.loadedLevel);
	}
}
