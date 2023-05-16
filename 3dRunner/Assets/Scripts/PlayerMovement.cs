using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;
    public bool is_grounded;
    public bool girando;
    public int tile;
    private bool action;
    public bool giro;
    public float jumpForce = 50.0f;
    public float speed = 9.0f;
    public int jump = 0;
    private Rigidbody playerRb;
    private int in_anim;
    public bool desactivar_giro;
    public bool desactivado;
    bool retroceder;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        desactivar_giro = false;
        giro = false;
    }

    // Update is called once per frame
    void Update()
     {
        action = Input.GetKeyDown(KeyCode.Space);
        if (tile == 1 && action && !giro && is_grounded)
        {
            if (!desactivar_giro || (playerRb.position.z % 2 < 0.3 || playerRb.position.z%2 >= 1)) {
                if (desactivar_giro && playerRb.position.z % 2 <= 0.3) retroceder = true;
                girando = true;
                giro = true;
                print("entra");
            }
        }
        else if (tile == 2 && action && !giro && is_grounded)
        {
            girando = true;
            giro = true;
        }
        else if (action && jump < 2 && in_anim == 0) {
            myAnim.StopPlayback();
            myAnim.Play("Running jump");
            playerRb.AddForce(new Vector3(0, 0.5f, 0) * jumpForce, ForceMode.Impulse);
            in_anim = 100;
            ++jump;
            is_grounded = false;
        }
        if (tile == 1 && playerRb.position.z%2 > 1 && !desactivado)
        {
            desactivar_giro = true;
            desactivado = true;
        }
        if (girando)
        {
            desactivar_giro = false;
            print(retroceder);
            if ((tile == 1 && playerRb.position.z % 2 > 1.5) || retroceder)
            {
                if (playerRb.position.z % 2 > 1.75 && playerRb.position.z % 2 < 2)
                {
                    transform.Translate(0, 0, -0.15f); 
                }
                if (retroceder) transform.Translate(0, 0, -0.5f);
                if (playerRb.position.z % 2 < 2 || retroceder)
                {
                    transform.Rotate(new Vector3(0f, 90f, 0f));
                    myAnim.StopPlayback();
                    myAnim.Play("Right turning");
                    in_anim = 60;
                }
                girando = false;
                retroceder = false;
            }
            else if (tile == 2 && playerRb.position.x % 2 > 1.8)
            {
                if (playerRb.position.x % 2 > 2)
                {
                    transform.Translate(0, 0, 1.5f);
                }
                transform.Rotate(new Vector3(0f, -90f, 0f));
                in_anim = 60;
                girando = false;
            }
        }
        if (in_anim > 0) --in_anim;
        if (is_grounded && in_anim == 0) myAnim.Play("running");
        //print(transform.position.y);
        transform.Translate(0, 0, speed * Time.deltaTime);
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}