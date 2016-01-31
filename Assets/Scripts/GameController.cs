using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	private bool isPaused = false;

	public GameObject pauseObject;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P) && !isPaused)
		{
			PauseGame(0f);
		}
		else if(Input.GetKeyDown(KeyCode.P) && isPaused)
		{
			PauseGame(1f);
		}
	}

	public void PauseGame(float timeScale)
	{
		isPaused = !isPaused;

		pauseObject.SetActive(!pauseObject.activeSelf);
		Time.timeScale = timeScale;
	}

	public void RestartGame()
	{
		ChoiceManager.GetInstance().choice = 0;
		SceneManager.LoadScene(0);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
