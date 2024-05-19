using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Camera cam;
    
    [Range(3, 7)]
    [SerializeField] private float fieldOfView;

    private Vector3 cameraPosition;
    private Vector3 smoothedPosition;

    private void LateUpdate()
    {
        cam.orthographicSize = fieldOfView;
        if (target != null)
        {
            cameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
