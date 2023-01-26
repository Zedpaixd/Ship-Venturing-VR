using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sanity check???"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, (transform.rotation.eulerAngles.y + 1)%360, 0);
        //Debug.Log(transform.rotation);
    }
}
