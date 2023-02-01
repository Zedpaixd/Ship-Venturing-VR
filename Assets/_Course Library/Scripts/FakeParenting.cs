using UnityEngine;

public class FakeParenting: MonoBehaviour
 {

    /// <summary>
    /// Simulated parenting without actually parenting objects
    /// </summary>

    [Tooltip("Fake Parent")]
    public Transform FakeParent;
    private Vector3 FakePos,
                    FakeForward,
                    FakeUp;

    void Start()
    {
        FakePos = FakeParent.transform.InverseTransformPoint(transform.position);
        FakeForward = FakeParent.transform.InverseTransformDirection(transform.forward);
        FakeUp = FakeParent.transform.InverseTransformDirection(transform.up);
    }

    void Update()
    {
        Vector3 newPosition = FakeParent.transform.TransformPoint(FakePos);
        Vector3 newForward = FakeParent.transform.TransformDirection(FakeForward);
        Vector3 newUp = FakeParent.transform.TransformDirection(FakeUp);
        Quaternion newrot = Quaternion.LookRotation(newForward, newUp);
        transform.position = newPosition;
        transform.rotation = newrot;
    }// pepehands im not smart enough
 
 }