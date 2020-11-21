using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourUI : MonoBehaviour
{
    [SerializeField] GameObject panelToShow;

    public virtual void Show()
    {
        panelToShow.SetActive(true);
    }

    public virtual void Hide()
    {
        panelToShow.SetActive(false);
    }
}
