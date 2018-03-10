using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomSceneTransition : MonoBehaviour 
{
	public RawImage fadeOutUIImage;
	public float fadeSpeed = 0.8f;
	public enum FadeDirection
	{
		In,
		Out
	}
	void OnEnable()
	{
		StartCoroutine(Fade(FadeDirection.Out));
	}

	IEnumerator Fade(FadeDirection fadeDirection)
	{
		float alpha = (fadeDirection == FadeDirection.Out)? 1:0;
		float fadeEndCalue = (fadeDirection == FadeDirection.Out)? 0 : 1;
		if(fadeDirection == FadeDirection.Out)
		{
			while(alpha>= fadeEndCalue)
			{
				SetColorImage(ref alpha, fadeDirection);
				yield return null;
			}
			fadeOutUIImage.enabled = false;
		}
		else
		{
			fadeOutUIImage.enabled = true;
			while(alpha <= fadeEndCalue)
			{
				SetColorImage(ref alpha, fadeDirection);
				yield return null;
			}
		}
	}

	public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
	{
		yield return Fade(fadeDirection);
		SceneManager.LoadScene(sceneToLoad);
	}

	private void SetColorImage(ref float alpha, FadeDirection fadeDir)
	{
		fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
		alpha += Time.deltaTime * (1.0f/fadeSpeed) * ((fadeDir == FadeDirection.Out)? -1 : 1);
	}
}
