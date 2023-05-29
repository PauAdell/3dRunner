using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{

    private Vector3 StartingPoint;
    [SerializeField] float blocksToMove;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aux = StartingPoint;
        if (transform.rotation.y == -90) aux.z += blocksToMove * Mathf.Sin(Time.time * speed);
        else if (transform.rotation.y == 0) aux.x += blocksToMove * Mathf.Sin(Time.time * speed);
        transform.position = aux;
    }
}