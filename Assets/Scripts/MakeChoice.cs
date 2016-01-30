using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeChoice : MonoBehaviour 
{

	private bool canMakeChoice = false;

	public Action target;
	public Text textObject;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E) && canMakeChoice)
		{
			target.BadChoice();
			canMakeChoice = false;
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D()
	{
		textObject.text = "Press E";
		canMakeChoice = true;
	}

	void OnTriggerExit2D()
	{
		canMakeChoice = false;
		textObject.text = "";
	}
}
