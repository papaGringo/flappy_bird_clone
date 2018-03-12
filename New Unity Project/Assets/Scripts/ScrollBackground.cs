using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour 
{
	public Rigidbody2D target;
	public float speed;

	private float initPos;

	void Start()
	{
		// initPos = transform.localPosition.x;
		initPos = transform.position.x;
		GameObject objCpy = GameObject.Instantiate(this.gameObject);
		Destroy(objCpy.GetComponent<ScrollBackground>());
		objCpy.transform.SetParent(this.transform);
		// Debug.Log(getWidth());
		objCpy.transform.localPosition = new Vector3(getWidth(), 0, 0);	
	}
	
	void FixedUpdate()
	{
		float targetVelocity = target.velocity.x;
		// this.transform.Translate(new Vector3(-speed * targetVelocity, 0, 0) * Time.deltaTime);
		target.velocity = Vector3.right * targetVelocity * -speed;
		Debug.Log(this.transform.position);

		float width = getWidth();

		if(targetVelocity > 0)
		{
			//if(initPos - this.transform.localPosition.x > width)
			if(initPos - this.transform.position.x > width)
			{
				// this.transform.Translate(new Vector3(width, 0, 0));
				target.velocity = Vector3.right * width;
			}
		}
		else
		{
			if(initPos - this.transform.position.x < 0)
			{
				//this.transform.Translate(new Vector3(-width,0,0));
				target.velocity = Vector3.right * -width;
			}
		}
	}

	float getWidth()
	{
		return this.GetComponent<SpriteRenderer>().bounds.size.x;
		
	}
}
