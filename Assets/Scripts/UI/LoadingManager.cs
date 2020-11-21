using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
	public bool nextScene = false;

	private void Update()
	{
		if (nextScene)
		{
			nextScene = false;
			NextScene();
		}
	}

	public void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}
