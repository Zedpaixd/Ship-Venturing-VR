using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Random.Range(0.00001f, 0.1f));
    }
}
