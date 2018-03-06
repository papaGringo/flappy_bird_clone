using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour 
{
	public Transform[] spawnPoints;
	public GameObject obstaclePrefab;
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

		StartCoroutine("AutoDestroy");
	}

	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(15);
		Destroy(gameObject);
	}
}
