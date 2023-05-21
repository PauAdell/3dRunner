using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;
    public bool is_grounded;
    public bool girando;
    public bool canviotex;
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
    public int muerte;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        desactivar_giro = false;
        giro = false;
        muerte = 0;
    }

    // Update is called once per frame
    void Update()
     {
        action = Input.GetKeyDown(KeyCode.Space);
        print(tile);
        if (tile == 1 && action && !giro && is_grounded)
        {
            if (!desactivar_giro || (playerRb.position.z % 2 < 0.3 || playerRb.position.z%2 >= 1)) {
                if (desactivar_giro && playerRb.position.z % 2 <= 0.3) retroceder = true;
                girando = true;
                giro = true;
            }
        }
        else if (tile == 2 && action && !giro && is_grounded)
        {
            if (!desactivar_giro || (playerRb.position.x % 2 < 0.5 || playerRb.position.x % 2 >= 1))
            {
                if (desactivar_giro && playerRb.position.x % 2 <= 0.5) retroceder = true;
                girando = true;
                giro = true;
            }
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
        if (tile == 2 && playerRb.position.x % 2 > 1 && !desactivado)
        {
            desactivar_giro = true;
            desactivado = true;
        }

        if (girando)
        {
            canviotex = true;
            if (tile == 1 && (playerRb.position.z % 2 > 1.55 || retroceder))
            {
                if (playerRb.position.z % 2 > 1.75)
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
                desactivar_giro = false;

            }
            else if (tile == 2 && (playerRb.position.x % 2 > 1.8 || retroceder))
            {
                if (playerRb.position.x % 2 > 1.9)
                {

                    transform.Translate(0, 0, -0.05f);
                }
                if (retroceder) transform.Translate(0, 0, -0.5f);
                if (playerRb.position.x % 2 < 2 || retroceder)
                {
                    transform.Rotate(new Vector3(0f, -90f, 0f));
                    myAnim.StopPlayback();
                    myAnim.Play("Right turning");
                    in_anim = 60;
                }
                girando = false;
                retroceder = false;
                desactivar_giro = false;
            }
        }
        if (in_anim > 0) --in_anim;
        if (muerte > 0) in_anim = 0;
        if (muerte == 1 && in_anim == 0)
        {
            myAnim.StopPlayback();
            myAnim.Play("Walk to die");
            in_anim = 300;
        }
        else if (muerte == 2 && in_anim == 0)
        {
            myAnim.StopPlayback();
            myAnim.Play("Dying Backwards");
            in_anim = 300;
        }
        else transform.Translate(0, 0, speed * Time.deltaTime);
        //print(muerte);
        if (is_grounded && in_anim == 0) myAnim.Play("running");
        //print(transform.position.y);
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}