using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform pfRadarPing;
    [SerializeField] private LayerMask layerMask;
    private float rotationSpeed;
    private Transform sweepTransform;
    private float radarDistance;
    private List<Collider> colliderList;

    private void Start()
    {
        
    }

    private void Awake()
    {
        sweepTransform = transform.Find("Sweep");
        rotationSpeed = 180f;
        radarDistance = 150f;
        colliderList = new List<Collider>();
    }

    private void Update()
    {
        float previousRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        float currentRotation = (sweepTransform.eulerAngles.z % 360) -180;

        if(previousRotation < 0 && currentRotation >= 0)
        {
            colliderList.Clear();
        }

        RaycastHit[] raycastHitArray = Physics.RaycastAll(transform.position, GetVectorFromAngle(sweepTransform.eulerAngles.z), radarDistance, layerMask);
        foreach(RaycastHit raycastHit in raycastHitArray)
        {
            if (raycastHit.collider != null)
            {
                if (colliderList.Contains(raycastHit.collider))
                {
                    colliderList.Add(raycastHit.collider);
                    RadarPing radarPing = Instantiate(pfRadarPing, raycastHit.point, Quaternion.identity).GetComponent<RadarPing>();
                }
            }
        }
        
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
