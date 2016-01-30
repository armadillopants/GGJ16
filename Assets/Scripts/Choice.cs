using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Choice : MonoBehaviour 
{
	public ChoiceType choiceType;

	private bool triggered = false;

	void OnTriggerEnter2D()
	{
		if(triggered)
		{
			return;
		}

		triggered = true;

		ChoiceManager.GetInstance().AddChoice((int)choiceType);
	}
}
