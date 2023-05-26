using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilMovement : MonoBehaviour
{
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
        current = 0;
        grado_giro = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerMovement.speed;
        //print(girando);
        if (girando)
        {
            if (tile == 1)
            {
                transform.Rotate(new Vector3(0f, 3f, 0f));
                grado_giro += 3;
            }
            else if (tile == 2)
            {
                transform.Rotate(new Vector3(0f, -3f, 0f));
                grado_giro -= 3;
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
