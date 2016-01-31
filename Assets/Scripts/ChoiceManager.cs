using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour 
{
	public int choice = 0;

	private static ChoiceManager _instance;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	public static ChoiceManager GetInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.Find("ChoiceManager").GetComponent<ChoiceManager>();
		}

		return _instance;
	}

	public void CalculateEnd()
	{
		GameObject finalChoice = GameObject.Find("FinalChoice");
		TextTrigger trigger = finalChoice.GetComponent<TextTrigger>();

		if(choice > 0)
		{
			trigger.storyText = "He came to accept his new reality, and the choices he made to get there truly showed where he was headed.";
		}
		else
		{
			trigger.storyText = "He never fully accepted his reality, and the choices he made to get there ultimately displayed his doomed destiny.";
		}
	}

	public void AddChoice(int choice)
	{
		this.choice += choice;
	}
}
