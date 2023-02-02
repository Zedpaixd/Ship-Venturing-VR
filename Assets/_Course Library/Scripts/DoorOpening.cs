using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    private Vector3 originalPosLeft;
    private Vector3 originalPosRight;

    private void Start()
    {
        originalPosLeft = doorLeft.transform.position;
        originalPosRight = doorRight.transform.position;
    }


    private void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(OpenDoor(doorLeft, originalPosLeft - new Vector3(0, 0, 1.1f)));
            StartCoroutine(OpenDoor(doorRight, originalPosRight + new Vector3(0, 0, 1.1f)));
        }

        
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(CloseDoor(doorLeft, originalPosLeft));
            StartCoroutine(CloseDoor(doorRight, originalPosRight));
        }
    }

    IEnumerator OpenDoor(GameObject door, Vector3 endPos)
    {
        float elapsedTime = 0;
        while (elapsedTime<1f) {
            door.transform.position = Vector3.Lerp(door.transform.position,endPos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator CloseDoor(GameObject door, Vector3 endPos)
    {
        float elapsedTime = 0;
        while (elapsedTime < 1f)
        {
            door.transform.position = Vector3.Lerp(door.transform.position,endPos, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
