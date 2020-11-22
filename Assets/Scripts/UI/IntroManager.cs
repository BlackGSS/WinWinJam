using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
	[SerializeField] MonoBehaviourUI[] intros;

	public int currentScene = 0;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < intros.Length; i++)
		{
			intros[i].Init();
		}
		StartCoroutine(DelayToIni());
	}

	IEnumerator DelayToIni()
	{
		yield return new WaitForSeconds(0.3f);
		intros[0].Show();
	}

	public void NextScreen()
	{
		int nextScene = currentScene + 1;

		intros[currentScene].Hide(() => intros[nextScene].Show());
		currentScene++;
	}

	public void NextScene()
	{
		intros[currentScene].Hide(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

	}
}
