using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpening : MonoBehaviour
{
    public GameObject bookCover;
    public HingeJoint HJ;
    void Start()
    {
        HingeJoint HJ = bookCover.GetComponent<HingeJoint>();
        HJ.useMotor = false;
    }

    private void CoverOpen()
    {
        HJ.useMotor = true;
    }
}
