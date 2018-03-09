using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGameManager : MonoBehaviour 
{
	public Transform birdPosition;
	public Vector3 offset = new Vector3(5,0,0);
	public GameObject obstacleGeneratorPrefab;
	private static BirdGameManager _instance;
	public static BirdGameManager Instance
	{
		get { return _instance;}
	}

	int score;

	void Awake()
	{
		if(_instance != null && _instance == this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}
	
	void Start()
	{
		obstacleQueue = new List<Transform>();
		InvokeRepeating("Generate", 0, Random.Range(3,5) );
		score = 0;
	}

	void Update()
	{
		if(obstacleQueue.Count > 0 && birdPosition.position.x > obstacleQueue[0].position.x)
		{
			//score++ ; //curObs = null;
			score++;
			Debug.Log(score);
			FindClosestCurObs();
		}
	}

	private void FindClosestCurObs()
	{
		if(obstacleQueue.Count>0)
		{
			curObsGenerator = obstacleQueue[0];
			//Destroy(curObsGenerator);
			obstacleQueue.RemoveAt(0);
			curObsGenerator.GetComponent<ObstacleGenerator>().canDestroy = true;
			curObsGenerator = null;
		}
	}

	private void Generate()
	{
		Instantiate(obstacleGeneratorPrefab, new Vector3( birdPosition.position.x , Random.Range(-.75f, 1.25f) , birdPosition.position.z ) + offset, birdPosition.rotation);
		if(curObsGenerator == null && obstacleQueue.Count == 0) curObsGenerator = obstacleGeneratorPrefab.transform;
		obstacleQueue.Add(curObsGenerator);
	}

	
	public List<Transform> obstacleQueue;
	private Transform curObsGenerator;
}
