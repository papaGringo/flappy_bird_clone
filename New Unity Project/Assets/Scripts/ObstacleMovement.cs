using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour 
{
	public float speedY = 0;
	public float switchTime = 2;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.up * Random.Range(speedY, speedY + 1.75f);
		InvokeRepeating("Switch", 0 , switchTime);
	}
	
	void Switch()
	{
		GetComponent<Rigidbody2D>().velocity *= -1;
	}
}
