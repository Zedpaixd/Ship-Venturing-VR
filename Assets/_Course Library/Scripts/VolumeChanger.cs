using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    public AudioSource al;

    private void Awake()
    {
        this.al = GetComponent<AudioSource>();
    }

    public void SetVolume(float x)
    {
        al.volume = x;
    }
}
