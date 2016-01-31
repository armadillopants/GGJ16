using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StrangeFigure : Action 
{

	public Text textObject;

	public GameObject[] buttons;

	public GameObject death;

	void OnTriggerEnter2D()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = false;
		Invoke("Speak", 8f);
	}

	void Speak()
	{
		textObject.text = "Mysterious Figure: Are you ready to accept your fate?";
		Invoke("ShowButtons", 3f);
		GameObject.Find("Meeting").GetComponent<AudioSource>().Play();

	}

	void ShowButtons()
	{
		foreach(GameObject button in buttons)
		{
			button.SetActive(true);
		}
	}

	void HideButtons()
	{
		foreach(GameObject button in buttons)
		{
			button.SetActive(false);
		}

		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
		GameObject.Find("Meeting").GetComponent<AudioSource>().Stop();
	}

	public override void GoodChoice ()
	{
		base.GoodChoice ();

		HideButtons();
		ChoiceManager.GetInstance().AddChoice((int)ChoiceType.GOOD_CHOICE);

		textObject.text = "He faced his fear, and walked through the dark alone.";

		Destroy(death);
	}

	public override void BadChoice ()
	{
		base.BadChoice ();

		HideButtons();
		ChoiceManager.GetInstance().AddChoice((int)ChoiceType.BAD_CHOICE);

		textObject.text = "He chose not to face this heavy burden";

		Destroy(death);
	}
}
