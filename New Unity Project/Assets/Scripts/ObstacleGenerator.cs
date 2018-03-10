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
				Instantiate(obstaclePrefab, spawnPoint);
			}
		}
		else
		{
			int randomIndex = Random.Range(0,spawnPoints.Length);
			Instantiate(obstaclePrefab, spawnPoints[randomIndex]);
		}
		canDestroy = false;
	}
	void Update()
	{
		if(canDestroy)
		{
			StartCoroutine(AutoDestroy());
		}
	}
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
}
