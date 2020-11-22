using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceAppear : MonoBehaviour
{
    [SerializeField] Material dissolveMat;
    [SerializeField] private float noiseStrength = 1.5f;
    [SerializeField] private float objectHeight = 1f;
    [SerializeField] private float maxHeight = 3;
    [SerializeField] private float minHeight = -1.5f;
    [SerializeField] GameObject trail;

    public float height = 0;
    bool isVisible = false;

    private void OnEnable()
    {
        dissolveMat.SetFloat("_CutoffHeight", minHeight);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isVisible)
        {
            var time = Time.deltaTime;

            height = dissolveMat.GetFloat("_CutoffHeight");
            height += time * (objectHeight);

            dissolveMat.SetFloat("_CutoffHeight", height);
            //dissolveMat.SetFloat("_NoiseStrength", noiseStrength);

            if (dissolveMat.GetFloat("_CutoffHeight") >= maxHeight)
            {
                isVisible = true;
                if(trail != null)
                    trail?.SetActive(true);
            }
        }
    }
}
