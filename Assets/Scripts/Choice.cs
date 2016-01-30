using UnityEngine;
using System.Collections;

public class Choice : MonoBehaviour 
{

	public string choice;
	public ChoiceType choiceType;

	void OnTriggerEnter2D(Collider2D col)
	{
		ChoiceManager.GetInstance().AddChoice((int)choiceType);
	}
}
