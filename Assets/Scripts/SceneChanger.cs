﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneChanger : MonoBehaviour 
{

	public string level;

	private bool triggered = false;

	void OnTriggerEnter2D()
	{
		if(triggered)
		{
			return;
		}

		triggered = true;

		StartCoroutine(FadeToSceneChange());
	}

	IEnumerator FadeToSceneChange()
	{
		GameObject fade = new GameObject("FadeObject");
		fade.AddComponent<GUITexture>();
		GUITexture guiTexture = fade.GetComponent<GUITexture>();

		Texture2D tex = new Texture2D(1, 1);
		tex.SetPixel(0, 0, Color.black);
		tex.Apply();
		guiTexture.texture = tex;

		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);

		float alpha = 0f;
		Color temp = guiTexture.color;
		while(alpha < 1.0f)
		{
			alpha += Time.deltaTime / 5f;
			temp.a = alpha;
			guiTexture.color = temp;
			yield return new WaitForSeconds(Time.deltaTime);
		}

		Destroy(fade);

		SceneManager.LoadScene(level);
	}
}
