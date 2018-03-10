using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour 
{
	public float speedY = 0;
	public float switchTime = 2;
	private Rigidbody2D rBody;
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D>();
		rBody.velocity = Vector2.up * Random.Range(speedY, speedY + 1.75f);
		InvokeRepeating("Switch", 0 , Random.Range(switchTime - 0.25f, switchTime + 0.25f ));
	}
	
	void Switch()
	{
		//rBody.velocity *= -1;
		rBody.velocity *= Random.Range(-1.6f, -1.3f);
	}
}
