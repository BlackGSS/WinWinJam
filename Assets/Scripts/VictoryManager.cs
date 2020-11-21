using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] VictoryData[] victories;
    [SerializeField] VictoryUIManager victoryUI;

    public static Action<int> onVictoryAchieve = (int id) => { };

    private void Awake()
    {
        onVictoryAchieve += VictoryAchieved;
    }

    private void VictoryAchieved(int victoryID)
    {
        victoryUI.Show(victories[victoryID]);
    }
}
