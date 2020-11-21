using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MonoBehaviourUI : MonoBehaviour
{
    [SerializeField] GameObject panelToShow;
    [SerializeField] float timeToFade = 1f;
    CanvasGroup fade;

    private void Awake()
    {
        fade = panelToShow.GetComponent<CanvasGroup>();
    }

    public virtual void Init()
    {
        fade.alpha = 0f;
        panelToShow.SetActive(false);
    }

    public virtual void Show()
    {
        if (!panelToShow.activeSelf)
        {
            panelToShow.SetActive(true);
            if (fade.alpha != 0)
                fade.alpha = 0;
        }

        Sequence sequence = DOTween.Sequence();
        sequence.Append(fade.DOFade(1, timeToFade));
        sequence.OnComplete(() => panelToShow.SetActive(true));
    }

    public virtual void Hide(Action oncomplete = null)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(fade.DOFade(0, timeToFade));
        sequence.OnComplete(() => ActionOnCompleteHide(oncomplete));

    }

    private void ActionOnCompleteHide(Action oncomplete)
    {
        if (oncomplete != null)
            oncomplete.Invoke();

        panelToShow.SetActive(false);
    }
}
