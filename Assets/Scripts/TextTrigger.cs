using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextTrigger : TriggerObject 
{
	private float fadeTextTime = 3f;

	public string storyText;
	public Text textObject;

	public override void OnTriggerEnter2D()
	{
		base.OnTriggerEnter2D();

		textObject.text = "";

		StartCoroutine(FadeInLetters());
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
