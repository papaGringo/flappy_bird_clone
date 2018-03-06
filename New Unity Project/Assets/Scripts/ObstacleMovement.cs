using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour 
{
	public float speed = 0;
	public float switchTime = 2;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		InvokeRepeating("Switch", 0 , switchTime);
	}

	void Switch()
	{
		GetComponent<Rigidbody2D>().velocity *= -1;
	}
}
