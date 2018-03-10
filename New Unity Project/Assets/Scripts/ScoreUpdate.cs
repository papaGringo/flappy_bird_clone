using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour 
{
	void Update () 
	{
		GetComponent<Text>().text = BirdGameManager.Instance.ScoreUI;	
	}
}
