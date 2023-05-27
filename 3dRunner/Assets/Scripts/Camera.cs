using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float distance = 30.0f;
    public float heightOffset = 30.0f;
    public float cameraDelay = 0.02f;

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = target.position + target.forward * distance;

        followPos.y += heightOffset;
        followPos.x += distance;
        transform.position += (followPos - transform.position) * cameraDelay;

        transform.LookAt(target.transform);
    }
}
