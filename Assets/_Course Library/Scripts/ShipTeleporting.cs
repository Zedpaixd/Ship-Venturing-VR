using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTeleporting : MonoBehaviour
{
    public GameObject position1;
    public GameObject position2;
    private bool nextTP = true; // true = position 2 ; false = position 1

    public void Teleport()
    {
        this.transform.position = nextTP ? position2.transform.position : position1.transform.position;
        this.transform.rotation = nextTP ? Quaternion.Euler(new Vector3(0,180,0)) : Quaternion.Euler(new Vector3(0, 0, 0));
        nextTP = !nextTP;
    }

    private void Update()
    {

        if (nextTP) position1.transform.position = this.transform.position;

        //if (Time.time == 0) Teleport();  // please give me a headset cable so i can get rid of this atrocity
    }
}
