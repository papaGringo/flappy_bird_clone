using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour 
{
	public float speed = 2;
	public float force = 300;
	private	 float	 inputY = 0f;
	private float inputDelay = 0.8f;
	public float gSpeed = 0.6f;
	private Rigidbody2D rBody;
	private int jumpCount = 0;
	private float curSpeed = 0f;
	private void GetInput()
	{
		inputY = Input.GetAxisRaw("Jump");
	}
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D>();
		rBody.velocity = Vector2.right * speed;
	}	
	void Update () 
	{
		GetInput();
		curSpeed = rBody.velocity.magnitude;		
	}
	void FixedUpdate()
	{
		if(!BirdGameManager.Instance.isGameOver)
		{
			if(Mathf.Abs(inputY)> inputDelay)
			{
				if(jumpCount > 0)
				{	
					return;
				}
				rBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
				jumpCount++;
			}
			rBody.AddForce(Vector2.up * -1 * gSpeed);
			jumpCount = 0;
			if(curSpeed < 3.5)
			{
				rBody.velocity = Vector2.right * speed;
			}
		}		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		//isDead = true;
		BirdGameManager.Instance.isGameOver = true;
		rBody.velocity = Vector2.zero;
	}
}
