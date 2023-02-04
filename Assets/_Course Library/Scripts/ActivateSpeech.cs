using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpeech : MonoBehaviour
{
    bool readOnce = false;
    [SerializeField] GameObject[] itemsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (!readOnce && other.transform.tag == "Player")
        {
            foreach (var thing in itemsToActivate)
            {
                thing.SetActive(!thing.activeSelf);
            }
            readOnce = true;
        }
    }
}