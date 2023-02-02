using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSuck : MonoBehaviour
{
    public float PullRadius; 
    public float GravitationalPull; 
    public float MinRadius; 
    public float DistanceMultiplier; 

    public LayerMask LayersToPull;
    public TeleportPlayer teleportPlayer;

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, PullRadius, LayersToPull);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb == null) continue;

            Vector3 direction = transform.position - collider.transform.position;

            if (direction.magnitude < MinRadius) continue;

            float distance = direction.sqrMagnitude * DistanceMultiplier + 1; 


            rb.AddForce(direction.normalized * (GravitationalPull / distance) * rb.mass * Time.fixedDeltaTime);
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(collision.gameObject);
            teleportPlayer.Teleport();
        }
    }
}
