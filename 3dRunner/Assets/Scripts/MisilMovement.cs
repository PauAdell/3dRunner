using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilMovement : MonoBehaviour
{
    Vector3 ini_pos;
    Quaternion rot_ini;
    public int tile;
    public bool girando;
    public bool giro;
    public float speed;
    public float current, target;
    public Vector3 goalPosition;
    public bool aprox;
    public int grado_giro;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        giro = false;
        girando = false;
        current = 0;
        aprox = false;
        grado_giro = 0;
        ini_pos = transform.position;
        speed = 0;
        rot_ini = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.start && transform.position != ini_pos)
        {
            transform.position = ini_pos;
            transform.rotation = rot_ini;
            speed = 0;
        }
        if (playerMovement.muerte != 0)
        {
            giro = false;
            girando = false;
            current = 0;
            aprox = false;
            grado_giro = 0;
            speed = 0;
        }
        else if (!playerMovement.start) gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        else if (playerMovement.start)
        {
            if (playerMovement.speed != 3) speed = playerMovement.speed;
            if (!playerMovement.is_grounded) speed = playerMovement.speed - 2.5f;
            if (girando)
            {
                if (tile == 1)
                {
                    transform.Rotate(new Vector3(0f, 5f, 0f));
                    grado_giro += 5;
                }
                else if (tile == 2)
                {
                    transform.Rotate(new Vector3(0f, -5f, 0f));
                    grado_giro -= 5;
                }
                if (grado_giro == 90 || grado_giro == -90)
                {
                    girando = false;
                    grado_giro = 0;
                }
            }
            transform.Translate(0, 0, speed * Time.deltaTime);
            if (aprox)
            {
                current = Mathf.MoveTowards(current, target, Time.deltaTime);
                Vector3 pos;
                if (tile == 1) pos = new Vector3(transform.position.x, transform.position.y, goalPosition.z);
                else pos = new Vector3(goalPosition.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, pos, current / target);
                if (transform.position == pos) aprox = false;
            }

        }
    }
}
