using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    /// <summary>
    /// Makes sure that the object containing the script will always target the player
    /// </summary>

    /// <PossibleIssue>
    /// Rotation may be inverted because of VR?
    /// </PossibleIssue>

    [Tooltip("Target for the camera to look at")]
    [SerializeField] public Transform target;
    [Tooltip("The amount of time it takes for the object to rotate")]
    [SerializeField] public int turnSpeed = 5; //slerp speed
 
    public void Update()
    {
        if (target) // make sure target exists
        {
            var rotationAngle = Quaternion.LookRotation(target.position - transform.position); // get angle for rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * turnSpeed); // rotate
        }
    }

}
