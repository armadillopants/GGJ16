using UnityEngine;
using System.Collections;

public class FinalChoice : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		ChoiceManager.GetInstance().CalculateEnd();
	}

	void OnTriggerEnter2D()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = false;
		Invoke("PlayerMove", 5f);
	}

	void PlayerMove()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
		Destroy(this);
	}
}
