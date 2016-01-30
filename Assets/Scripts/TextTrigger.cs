using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class TextTrigger : MonoBehaviour 
{
	private float fadeTextTime = 3f;

	public string storyText;
	public Text textObject;

	private bool triggered = false;

	void OnTriggerEnter2D()
	{
		if(triggered)
		{
			return;
		}
		//StopCoroutine(FadeInLetters());
		//Reset();
		textObject.text = "";

		StartCoroutine(FadeInLetters());
		triggered = true;
	}

	IEnumerator FadeInLetters()
	{
		yield return new WaitForSeconds(0.09f);
		if(storyText.Length != textObject.text.Length)
		{
			textObject.text = storyText.Substring(0, textObject.text.Length + 1);
			StartCoroutine(FadeInLetters());
		}
		else
		{
			//textObject.CrossFadeAlpha(0f, fadeTextTime, true);
		}
	}

	void Reset()
	{
		Color color = textObject.color;
		color.a = 1f;
		textObject.color = color;
	}
}
