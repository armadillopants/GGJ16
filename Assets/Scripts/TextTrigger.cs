using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour 
{

	public string storyText;
	public Text textObject;

	void OnTriggerEnter2D()
	{
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
	}
}
