using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;
    public bool is_grounded;
    public int tile;
    private bool action;
    public bool giro;
    public float jumpForce = 50.0f;
    public float speed = 9.0f;
    public int jump = 0;
    private Rigidbody playerRb;
    private int in_anim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
     {
        action = Input.GetKeyDown(KeyCode.Space);
        //print(speed);
        if (tile == 1 && action && !giro && is_grounded)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
            giro = true;
            myAnim.StopPlayback();
            myAnim.Play("Right turning");
            in_anim = 60;

        }
        else if (tile == 2 && action && !giro && is_grounded)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
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
        if (in_anim > 0) --in_anim;
        if (is_grounded && in_anim == 0) myAnim.Play("running");
        //print(transform.position.y);
        transform.Translate(0, 0, speed * Time.deltaTime);
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}