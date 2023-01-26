using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDart : MonoBehaviour
{
    public GameObject dartPrefab;
    [SerializeField] [Range(1,50)] private float dartSpeed = 5;
    private Rigidbody dartRB;
    public Transform location;

    void Start()
    {
        dartRB = dartPrefab.GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        var bullet = Instantiate(dartPrefab, location);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(location.forward*dartSpeed, ForceMode.Impulse);
    }
}
