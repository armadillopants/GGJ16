using UnityEngine;
using System.Collections;

public class Choice : TriggerObject 
{
	public ChoiceType choiceType;

	public override void OnTriggerEnter2D()
	{
		base.OnTriggerEnter2D();

		ChoiceManager.GetInstance().AddChoice((int)choiceType);
	}
}
