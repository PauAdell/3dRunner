using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool left_turn, right_turn;
    public float speed = 7.0f;
    private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        left_turn = Input.GetKeyDown(KeyCode.A);
        right_turn = Input.GetKeyDown(KeyCode.D);

        if (left_turn)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (right_turn)
            transform.Rotate(new Vector3(0f, 90f, 0f));

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
    }
}