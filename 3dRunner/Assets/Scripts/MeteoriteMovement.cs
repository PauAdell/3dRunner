using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        target.z -= 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}