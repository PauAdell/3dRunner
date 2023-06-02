using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : MonoBehaviour
{
    public Vector3 target;
    private Vector3 ini_pos;
    public float speed;
    public bool arrancar;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        arrancar = false;
        speed = 3;
        ini_pos = transform.position;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.start)
        {
            arrancar = false;
            transform.position = ini_pos;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<ParticleSystem>().Play();
        }
        else if (arrancar && playerMovement.muerte == 0) transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }
}