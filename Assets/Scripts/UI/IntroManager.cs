using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
	[SerializeField] MonoBehaviourUI intro1;
	[SerializeField] MonoBehaviourUI intro2;

	private void Awake()
	{
		intro1.Init();
		intro2.Init();
	}

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(DelayToIni());
	}

	IEnumerator DelayToIni()
	{
		yield return new WaitForSeconds(0.3f);
		intro1.Show();
	}

	public void NextScreen()
	{
		intro1.Hide(() => intro2.Show());
	}

	public void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}
