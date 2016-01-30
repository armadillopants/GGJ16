using UnityEngine;
using System.Collections;

public class Choice : MonoBehaviour 
{
	public ChoiceType choiceType;

	void OnTriggerEnter2D()
	{
		ChoiceManager.GetInstance().AddChoice((int)choiceType);
	}
}
