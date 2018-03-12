using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour 
{
	public Transform[] spawnPoints;
	public GameObject obstaclePrefab;
	public bool canDestroy;	
	void Start () 
	{
		int randomLength = Random.Range(1,spawnPoints.Length + 1);		
		if(randomLength == 2)
		{
			//spawn both
			foreach(Transform spawnPoint in spawnPoints)
			{
				GameObject go =	Instantiate(obstaclePrefab, spawnPoint);
				go.transform.SetParent(spawnPoint);
			}
		}
		else
		{
			int randomIndex = Random.Range(0,spawnPoints.Length);
			GameObject go = Instantiate(obstaclePrefab, spawnPoints[randomIndex]);
			go.transform.SetParent(spawnPoints[randomIndex]);
		}
		canDestroy = false;
	}
	void Update()
	{
		if(canDestroy)
		{
			StartCoroutine(AutoDestroy());
		}
		foreach(Transform spawnPoint in spawnPoints)
		{
			spawnPoint.GetChild(0).localPosition = spawnPoint.localPosition;
		}
	}

	void FixedUpdate()
	{
		transform.GetComponent<Rigidbody2D>().velocity = Vector2.left * 2f;
	}
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
}
