using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearsAtGo : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Cambiar por Shader Dissolve y desactivar collider
            gameObject.SetActive(false);
        }
    }

}
