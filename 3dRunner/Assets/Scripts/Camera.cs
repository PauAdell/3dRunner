using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Vector3 pos;
    public Transform target;
    public Transform target2;
    public float distance;
    public float heightOffset;
    public float cameraDelay;
    bool empieza;
    Vector3 current;

    public PlayerMovement playerMovement;

    private void Start()
    {
        pos = transform.position;
        current = target2.transform.position;
        empieza = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward;
        Vector3 followPos;
        if (!playerMovement.start)
        {
            empieza = false;
            forward = new Vector3(0f, 0f, 1f);
            //followPos.y += heightOffset;
            followPos = pos;
            followPos.x += 5;
            followPos.y += 5;
            transform.position = followPos;
            transform.LookAt(target2.transform);
        }
        else
        {
            forward = new Vector3(0f, 0f, 1f);
            followPos = target.position + forward * distance;
            followPos.y += heightOffset;
            followPos.x += distance;
            Vector3 pos_aux = transform.position + (followPos - transform.position);
            if (!empieza) transform.position = Vector3.Lerp(transform.position, pos_aux, 0.01f);
            else transform.position = pos_aux;
            if (transform.position.z >= 16.5) empieza = true;
            transform.LookAt(target.transform);
        }
    }
}
