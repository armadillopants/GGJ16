using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour 
{
	public string level;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			ChoiceManager.GetInstance().choice += 1;
			SceneManager.LoadScene(level);
		}
	}
}
