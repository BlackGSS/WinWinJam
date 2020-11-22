using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class InitManager : MonoBehaviour
{
    public VolumeProfile startProfile;
    public VolumeProfile newProfile;

    public static Action onHeadTake = () => { };

    private void Awake()
    {
        GetComponent<Volume>().profile = startProfile;

    }

    private void Start()
    {
        onHeadTake += Taken;
    }

    private void Taken()
    {
        GetComponent<Volume>().profile = newProfile;
    }
}
