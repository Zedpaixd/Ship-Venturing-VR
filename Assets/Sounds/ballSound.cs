using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSound : MonoBehaviour
{

    public AudioClip sound;
    private AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        AS.PlayOneShot(sound, 0.4F);
    }

    // I don't have headphones so i can not test this out but it shouuuuuuuuuuuuuuuuuuuuuld work?
    // at least i hope
    // idk
    // lol
    // anyway
    // why are you still reading this
    // whatever
    // hope you're having a good day

}
