using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerExt : MonoBehaviour 
{
	public GameObject camBGPrefab;
	public GameObject birdPrefab;
	public GameObject obstaclePrefab;
	public List<GameObject> obstacles = new List<GameObject>();
	private static GameManagerExt instance;	
	public static GameManagerExt Instance
	{
		get
		{
			return instance;
		}
	}
	void Awake()
	{
		if(instance != null && instance == this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	void Start()
	{
		Instantiate(camBGPrefab, Vector2.zero, camBGPrefab.transform.rotation);
		Instantiate(birdPrefab, Vector2.zero, birdPrefab.transform.rotation);
		InvokeRepeating("GenerateObstacle", 3, Random.Range(2, 4));
	}
	void Update()
	{
		if(obstacles.Count > 0 && obstacles[0].transform.position.x + 0.10f < Vector2.zero.x)
		{
			obstacles[0].GetComponent<ObstacleMovementExt>().canDestroy = true;
			obstacles.RemoveAt(0);
		}
	}
	private void GenerateObstacle()
	{
		Vector2 randomSpawnPos = new Vector2(Vector2.zero.x + 20.0f, Random.Range(-0.75f, 1.25f) );
		GameObject obs = Instantiate(obstaclePrefab, randomSpawnPos, obstaclePrefab.transform.rotation);
		obstacles.Add(obs);
	}
}
