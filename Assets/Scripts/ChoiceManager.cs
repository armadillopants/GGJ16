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

		switch(choice)
		{
			case 3:
				trigger.storyText = "He came to accept his new reality, and the choices he made to get there truly showed where he was headed.";
				break;
			case 2:
				trigger.storyText = "He stumbled along the way, but in the end he came to appreciate this thing he called life.";
				break;
			case 1:
				trigger.storyText = "He had reached the end of his journey, but he had a lot more work to do.";
			break;
			case -1:
				trigger.storyText = "He almost made it, but he had one shot, and he blew it. One decision had changed it all.";
				break;
			case -2:
				trigger.storyText = "He committed crimes he couldn't take back, faults too great to save him now. He was doomed from the start.";
				break;
			case -3:
				trigger.storyText = "He never fully accepted his reality, and the choices he made to get there ultimately displayed his doomed destiny.";
				break;
		}
	}

	public void AddChoice(int choice)
	{
		this.choice += choice;
	}
}
