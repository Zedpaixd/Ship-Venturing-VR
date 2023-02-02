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
    public List<Collider> colliderList;
    public PlayQuickSound playRadarSound;

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
        float previousRotation = (sweepTransform.eulerAngles.y % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        float currentRotation = (sweepTransform.eulerAngles.y % 360) - 180;

        if(previousRotation < 0 && currentRotation >= 0)
        {
            colliderList.Clear();
        }

        RaycastHit[] raycastHitArray = Physics.RaycastAll(transform.position, GetVectorFromAngle(sweepTransform.eulerAngles.y), radarDistance, layerMask);
        foreach(RaycastHit raycastHit in raycastHitArray)
        {
            if (raycastHit.collider != null)
            {
                if (!colliderList.Contains(raycastHit.collider))
                {
                    colliderList.Add(raycastHit.collider);
                    Instantiate(pfRadarPing, raycastHit.point, Quaternion.Euler(90,0,0));
                    playRadarSound.Play();
                }
            }
        }
        
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(-angleRad),0, Mathf.Sin(-angleRad));
    }
}
