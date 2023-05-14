using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;
    public bool is_grounded;
    public int tile;
    private bool action;
    private bool jump1;
    private int time_to_jump;
    public bool giro;
    public float jumpForce = 50.0f;
    public float speed = 9.0f;
    public int jump = 0;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        jump1 = false;
    }

    // Update is called once per frame
    void Update()
     {
        action = Input.GetKeyDown(KeyCode.Space);
        //print(speed);
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
        else if (action && jump < 2 && !jump1) {
            myAnim.StopPlayback();
            myAnim.Play("Running jump");
            playerRb.AddForce(new Vector3(0, 0.5f, 0) * jumpForce, ForceMode.Impulse);
            time_to_jump = 100;
            ++jump;
            jump1 = true;
            is_grounded = false;
        }
        if (jump1) --time_to_jump;
        if (time_to_jump == 0) jump1 = false;
        if (is_grounded) myAnim.Play("running");
        //print(transform.position.y);
        transform.Translate(0, 0, speed * Time.deltaTime);
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}