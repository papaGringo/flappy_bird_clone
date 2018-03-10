using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private int score;
	public List<Transform> obstacleQueue;
	private Transform curObsGenerator;
	public bool isGameOver = false;
	public string ScoreUI
	{
		get
		{
			return score.ToString();
		}
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
		obstacleQueue = new List<Transform>();
		InvokeRepeating("Generate", 0, Random.Range(2,4) );
		score = 0;
		isGameOver = false;
	}
	void Update()
	{
		if(obstacleQueue.Count > 0 && birdPosition.position.x > obstacleQueue[0].position.x + 0.2f)
		{
			curObsGenerator = obstacleQueue[0];
			score++;
			FindClosestCurObs();
		}
		if(isGameOver)
		{
			CancelInvoke();
			if(obstacleQueue.Count>0)
			{
				obstacleQueue[0].GetComponent<ObstacleGenerator>().canDestroy = true;
				obstacleQueue.RemoveAt(0);
			}
			StartCoroutine(GameObject.FindObjectOfType<Canvas>().GetComponent<CustomSceneTransition>().FadeAndLoadScene( CustomSceneTransition.FadeDirection.Out, "gameOverScene"));
		}
	}
	private void FindClosestCurObs()
	{
		if(obstacleQueue.Count>0)
		{
			curObsGenerator.GetComponent<ObstacleGenerator>().canDestroy = true;
			curObsGenerator = null;
			curObsGenerator = obstacleQueue[0];
			obstacleQueue.RemoveAt(0);
		}
	}
	private void Generate()
	{
		GameObject obsPre = Instantiate(obstacleGeneratorPrefab, new Vector3( birdPosition.position.x , Random.Range(-.75f, 1.25f) , birdPosition.position.z ) + offset, birdPosition.rotation);
		obstacleQueue.Add(obsPre.transform);
	}	
}
