using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public MonoBehaviourUI creditPanel;

    public void ShowCredits()
    {
        if (creditPanel.panelToShow.activeSelf)
            creditPanel.Hide();
        else
            creditPanel.Show();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
