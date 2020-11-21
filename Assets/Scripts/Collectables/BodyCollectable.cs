using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart { HEAD, BOOTS, CABLES }
public class BodyCollectable : MonoBehaviour
{
    private BodyPart category;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
