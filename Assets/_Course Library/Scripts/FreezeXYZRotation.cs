using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeXYZRotation : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;
    public string note = "We do not trust Rigidbodies";
    void Update()
    {
        if (x) transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z));
        if (y) transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z));
        if (z) transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0));
    }
}
