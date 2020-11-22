using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collactable : MonoBehaviour
{
    public float timeToHide;
    public AudioSource audioSource;
    public AudioClip clip;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ToastManager.Instance.SetText(GetComponent<CollectableLanguage>().GetCurrentText(), timeToHide);
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            gameObject.SetActive(false);
        }
    }

    protected virtual void OnDisable()
    {
        Destroy(gameObject);
    }
}
