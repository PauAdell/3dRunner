using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float distance = 35.0f;
    public float heightOffset = 30.0f;
    public float cameraDelay = 0.02f;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = new Vector3(0f, 0f, 1f);
        Vector3 followPos = target.position + forward * distance;
        followPos.y += heightOffset;
        followPos.x += distance;
        transform.position += (followPos - transform.position);

        transform.LookAt(target.transform);
    }
}
