using UnityEngine;

/// <summary>
/// Move an object using velocity
/// </summary>


[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    [Tooltip("Departed")]
    public bool departed = false;
    [Tooltip("Speed")]
    public float speed = 1.0f;
    [Tooltip("Direction")]
    public Transform componentDirection = null;
    [Tooltip("Rotation")]
    public float angle = 0;
    /*[Tooltip("Apply Movement To")]
    public GameObject[] gameObjects;*/

    public Vector3 inputVelocity = new Vector3(0,0,0);
    private Rigidbody RB = null;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (departed)
        {
            ApplyVelocity();
            Rotate(angle);
        }

    }

    private void ApplyVelocity()
    {
        Vector3 targetVelocity = inputVelocity * speed;
        targetVelocity = componentDirection.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - RB.velocity;
        RB.AddForce(velocityChange, ForceMode.VelocityChange);
        
        /*foreach (var gameObject in gameObjects)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(velocityChange,ForceMode.VelocityChange);
        }*/
    }

    public void SetForwardVelocity(float value)
    {
        inputVelocity.z = value;
    }

    public void Rotate(float value)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,value,0));
        /*foreach (var gameObject in gameObjects)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, value, 0));
        }*/
    }

    private void OnValidate()
    {
        if (!componentDirection)
            componentDirection = transform;
    }
}
