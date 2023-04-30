using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int tile;
    private bool action;
    public bool giro;
    public float velocidadSalto;
    private float velocidady;
    public float speed = 9.0f;
    private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
     {
        action = Input.GetKeyDown(KeyCode.Space);

        velocidady += Physics.gravity.y * Time.deltaTime;
        if (action) print("action");
        if (tile == 1 && action && !giro)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
            giro = true;

        }
        else if (tile == 2 && action && !giro)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
            giro = true;
        }
        else if (action) {

            velocidady = velocidadSalto;


        }


        Vector3 velocidad = new Vector3(0f, 0f, 0f);
        velocidad.y = velocidady;
        myCharacterController.Move(velocidad*Time.deltaTime);
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}