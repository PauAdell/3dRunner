using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int tile;
    private bool action;
    public bool giro;
    public float jumpForce = 50.0f;
    public float speed = 9.0f;
    public int jump = 0;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
     {
        action = Input.GetKeyDown(KeyCode.Space);
        //print(speed);
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
        else if (action && jump < 2) {
            playerRb.AddForce(new Vector3(0, 0.5f, 0) * jumpForce, ForceMode.Impulse);
            ++jump;
        }
        print(jump);
        //print(transform.position.y);
        transform.Translate(0, 0, speed * Time.deltaTime);
        //myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}