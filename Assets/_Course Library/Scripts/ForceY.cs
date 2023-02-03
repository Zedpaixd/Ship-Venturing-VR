using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceY : MonoBehaviour
{
    public GameObject child;

    // Update is called once per frame
    void Update()
    {
        child.transform.localPosition = new Vector3(child.transform.localPosition.x,0.5f,child.transform.localPosition.z);
    }
}
