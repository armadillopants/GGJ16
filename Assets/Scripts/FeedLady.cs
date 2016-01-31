using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeedLady : Action 
{
	public GameObject toDestroy;
	public Text textObject;

	public override void GoodChoice ()
	{
		base.GoodChoice ();

		Destroy(toDestroy);

		textObject.text = "He gave her some food, and saved her life. His face lit up with relief.";
		ChoiceManager.GetInstance().AddChoice((int)ChoiceType.GOOD_CHOICE);
	}
}
