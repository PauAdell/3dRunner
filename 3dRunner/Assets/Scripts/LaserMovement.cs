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
        aux.z += blocksToMove * Mathf.Sin(Time.time * speed);
        transform.position = aux;
    }
}