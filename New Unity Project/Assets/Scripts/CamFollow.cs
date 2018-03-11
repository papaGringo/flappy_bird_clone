using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour 
{
	public Transform target;
	void LateUpdate () 
	{
		transform.position = new Vector3(target.position.x - 2.0f, transform.position.y, transform.position.z)	;
	}
}
