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
		obstacleQueue = new Queue<Transform>();
		InvokeRepeating("Generate", 0, Random.Range(3,5) );
	}

	void Update()
	{
		if(curObsGenerator != null && (birdPosition.position.x > curObsGenerator.position.x))
		{
			//score++ ; //curObs = null;
			FindClosestCurObs();
		}
		else
		{
			//find closest curObs;
			FindClosestCurObs();

		}
	}

	private void FindClosestCurObs()
	{
		if(obstacleQueue.Count>0)
		{
			curObsGenerator = obstacleQueue.Peek();
			obstacleQueue.Dequeue();
		}
	}

	private void Generate()
	{
		Instantiate(obstacleGeneratorPrefab, new Vector3( birdPosition.position.x , Random.Range(-.75f, 1.25f) , birdPosition.position.z ) + offset, birdPosition.rotation);
		if(curObsGenerator == null)
		{
			curObsGenerator = obstacleGeneratorPrefab.transform;
			obstacleQueue.Enqueue(curObsGenerator);
		}
	}

	
	public Queue<Transform> obstacleQueue;
	private Transform curObsGenerator;
}
