using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFromLevel : MonoBehaviour
{
    [SerializeField] GameObject levelPlaceToGo;

    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        PlayerMovement.onFallingFromLevel.Invoke(levelPlaceToGo.transform);
    }
}
