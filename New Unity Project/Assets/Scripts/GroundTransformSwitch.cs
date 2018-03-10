using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundTransformSwitch : MonoBehaviour 
{
	private float speed = 1.25f;
	private Rigidbody2D rBody;
	// Use this for initialization
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D>();
		rBody.velocity = Vector2.right * speed * -1;
		InvokeRepeating("Switch", 0, 2);
	}
	void Update()
	{
		if(BirdGameManager.Instance.isGameOver)
		{
			CancelInvoke();
			rBody.velocity = Vector2.zero;
		}
	}
	private void Switch()
	{
		rBody.velocity *= -1;
	}
}
