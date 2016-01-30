using UnityEngine;
using System.Collections;

public class ChoiceManager : MonoBehaviour 
{
	public int choice = 0;

	private static ChoiceManager _instance;

	public static ChoiceManager GetInstance()
	{
		if(_instance == null)
		{
			_instance = new ChoiceManager();
		}

		return _instance;
	}

	public void AddChoice(int choice)
	{
		this.choice += choice;
	}
}
