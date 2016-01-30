using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour 
{
	public string level;

	void OnTriggerEnter2D()
	{
		SceneManager.LoadScene(level);
	}
}
