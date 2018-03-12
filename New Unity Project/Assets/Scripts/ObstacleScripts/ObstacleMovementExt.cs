using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementExt : MonoBehaviour 
{
	public Vector2 velocity = new Vector2(-1, 1);
	public float speedX= 2;
	public float speedY = 2;
	public float switchTime = 2f;
	public Rigidbody2D rBody;
	public bool canDestroy = false;
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D>();
		velocity.x *= Random.Range(speedX + 0.25f, speedX + 0.75f );
		velocity.y *= Random.Range(speedY - 0.25f, speedY + 1.75f );
		rBody.velocity = velocity;
		InvokeRepeating("Switch", 0, Random.Range(switchTime - 0.25f, switchTime + 0.25f ));
		canDestroy = false;
	}
	void Update()
	{
		if(canDestroy)
		{
			StartCoroutine(AutoDestroy());
		}
	}	
	void Switch()
	{
		velocity.y *= -1f;
		//velocity.y *= Random.Range(-1.6f, -1.2f);;
		rBody.velocity = velocity;
	}
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}
}
