using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : MonoBehaviour
{
    public float timeToHide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ToastManager.Instance.SetText(GetComponent<CollectableLanguage>().GetCurrentText(), timeToHide);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
