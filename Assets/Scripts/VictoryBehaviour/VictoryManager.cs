using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
	[SerializeField] VictoryData[] victories;

	public PlayerMovement player;

	public static Action<int> onVictoryAchieve = (int id) => { };

	private void Awake()
	{
		onVictoryAchieve += VictoryAchieved;
	}

	private void VictoryAchieved(int victoryID)
	{
		if (player.bootsEquipment)
			victoryID = 1;

		if (GlobalLanguage.CurrentLanguage == "English")
			ToastManager.Instance.SetText(victories[victoryID].textWinEng, 20f);

		if (GlobalLanguage.CurrentLanguage == "Spanish")
			ToastManager.Instance.SetText(victories[victoryID].textWinSpa, 20f);

		if (GlobalLanguage.CurrentLanguage == "Galician")
			ToastManager.Instance.SetText(victories[victoryID].textWinGal, 20f);
	}
}
