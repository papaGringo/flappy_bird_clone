using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour 
{
	public Vector2 velocity = new Vector2(-1f,1f);
	public float speedX = 0.75f;
	public float speedY = 0.1f;
	public float switchTime = 1f;
	private Rigidbody2D rBody;
	void Start()
	{
		rBody = GetComponent<Rigidbody2D>();
		velocity.x *= speedX;
		velocity.y *= speedY;
		rBody.velocity = velocity;
		InvokeRepeating("Switch", 0, switchTime);
		StartCoroutine(AutoDestroy());
	}
	void Switch()
	{
		velocity.y *= -1f;
		rBody.velocity = velocity;
	}
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(30);
		Destroy(gameObject);
	}
}
