using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart { HEAD = 0, WIRE, BOOTS }
public class BodyCollectable : MonoBehaviour
{
    [SerializeField] BodyPart category;
    [SerializeField] GameObject father;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement.onBodyPartGotIt.Invoke(category);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Destroy(father);
    }
}