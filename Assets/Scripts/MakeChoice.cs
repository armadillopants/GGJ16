using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeChoice : MonoBehaviour 
{
	public bool makeGoodChoice = false;
	private bool canMakeChoice = false;

	public Action target;
	public Text textObject;
	public string text;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E) && canMakeChoice)
		{
			if(makeGoodChoice)
			{
				target.GoodChoice();
			}
			else
			{
				target.BadChoice();
			}
			canMakeChoice = false;
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D()
	{
		textObject.text = text;
		canMakeChoice = true;
	}

	void OnTriggerExit2D()
	{
		canMakeChoice = false;
		textObject.text = "";
	}
}
