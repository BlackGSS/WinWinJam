using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryUIManager : MonoBehaviourUI
{
    public Image imageSprite;
    public TextMeshProUGUI textW;

    void Init()
    {
        Hide();
    }

    public void Show(VictoryData data)
    {
        imageSprite.sprite = data.imageWin;
        textW.text = data.textWin;

        Show();
    }
}
