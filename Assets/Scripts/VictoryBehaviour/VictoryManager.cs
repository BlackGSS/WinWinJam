using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
	[SerializeField] VictoryData[] victories;
	[SerializeField] GameObject resetGame;

	public PlayerMovement player;

	public static Action<int> onVictoryAchieve = (int id) => { };

	private void Awake()
	{
		onVictoryAchieve += VictoryAchieved;
	}

	private void VictoryAchieved(int victoryID)
	{

		resetGame.SetActive(true);

		if (player.bootsEquipment)
			victoryID = 1;

		if (GlobalLanguage.CurrentLanguage == "English")
			ToastManager.Instance.SetText(victories[victoryID].textWinEng, 40f);

		if (GlobalLanguage.CurrentLanguage == "Spanish")
			ToastManager.Instance.SetText(victories[victoryID].textWinSpa, 40f);

		if (GlobalLanguage.CurrentLanguage == "Galician")
			ToastManager.Instance.SetText(victories[victoryID].textWinGal, 40f);

		StartCoroutine(EndGame());
	}

	public void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(40f);

		//SceneManager.LoadScene("Menu");

	}
}
