using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdGameManager : MonoBehaviour 
{
	[System.Serializable]
	public class ScoreManager
	{
		private int score = 0;
		public int Score { get { return score; } }
		public ScoreManager()
		{
			score = 0;
		}

		public void UpdateScore()
		{
			score++;
		}		
	}

	[System.Serializable]
	public class BirdHandler
	{
		public GameObject birdPrefab;
		public GameObject bird;
		public Vector3 birdPos;
		public Quaternion birdRot;
		public void Initiate()
		{
			if(birdPrefab != null)
			{
				bird = Instantiate(birdPrefab, Vector3.zero, birdPrefab.transform.rotation);
				birdPos = bird.transform.position;
				birdRot = bird.transform.rotation;
				//GameObject.FindGameObjectWithTag("camBgHolder").GetComponent<CamFollow>().target = birdPrefab.transform;
			}
			else
			{
				Debug.LogError("Bird Prefab Missing");
			}
		}

		public void FetchTransform()
		{
			birdPos = bird.transform.position;
			birdRot = bird.transform.rotation;
		}		
	}

	[System.Serializable]
	public class ObstacleHandler
	{
		public float xPadding = 0.25f;
		public GameObject obstaclePrefab;
		public List<Transform> obstacles = new List<Transform>();
		public Vector3	spawnOffset = new Vector3(5,0,0);
		
		public void ClearList()
		{
			obstacles.Clear();
		}

		public void Dequeue()
		{
			if(obstacles.Count > 0)
			{
				obstacles[0].GetComponent<ObstacleGenerator>().canDestroy = true;
				obstacles.RemoveAt(0);
			}
		}
	}

	[System.Serializable]
	public class CamBgHandler
	{
		public GameObject camBGPrefab;
		public GameObject camBG;
		public CamFollow camFollow;
		public void Initiate()
		{
			camBG = Instantiate(camBGPrefab, Vector3.zero, camBGPrefab.transform.rotation);
			camFollow = camBG.GetComponent<CamFollow>();
		}
	}

	private static BirdGameManager _instance;
	public static BirdGameManager Instance
	{
		get { return _instance;}
	}	
	public bool isGameOver = false;
	public string ScoreUI
	{
	 	get
	 	{
	 		return scoreManager.Score.ToString();
	 	}
	 }

	public ScoreManager scoreManager;
	public ObstacleHandler obstacleHandler;
	public BirdHandler birdHandler;
	public CamBgHandler camBgHandler;
	private void InitiateHandler()
	{
		scoreManager = new ScoreManager();
		obstacleHandler = new ObstacleHandler();
		birdHandler = new BirdHandler();
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
		birdHandler.Initiate();
		camBgHandler.Initiate();
		camBgHandler.camFollow.target = birdHandler.bird.transform;
		isGameOver = false;
		InvokeRepeating("Generate", 3, Random.Range(2,4));
	}
	void Update()
	{
		birdHandler.FetchTransform();
		if(obstacleHandler.obstacles.Count > 0 && birdHandler.birdPos.x > obstacleHandler.obstacles[0].position.x + obstacleHandler.xPadding)
		{
			scoreManager.UpdateScore();
			obstacleHandler.Dequeue();
		}
		if(isGameOver)
		{
			CancelInvoke();			
			obstacleHandler.Dequeue();
			// StartCoroutine(GameObject.FindObjectOfType<Canvas>().GetComponent<CustomSceneTransition>().FadeAndLoadScene( CustomSceneTransition.FadeDirection.Out, "gameOverScene"));
		}
	}	
	private void Generate()
	{
		Vector3 randomSpawnPos = new Vector3( birdHandler.birdPos.x , Random.Range(-.75f, 1.25f) , birdHandler.birdPos.z ) + obstacleHandler.spawnOffset;
		GameObject obstacle = Instantiate(obstacleHandler.obstaclePrefab, randomSpawnPos , birdHandler.birdRot);
		obstacleHandler.obstacles.Add(obstacle.transform);
	}	
}
