using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "victoryData", menuName = "VictoryData", order = 0)]
public class VictoryData : ScriptableObject
{
    public Sprite imageWin;
    public string textWinSpa;
    public string textWinEng;
    public string textWinGal;
}
