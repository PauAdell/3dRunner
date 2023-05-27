using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private float initial_speed;

    void Start()
    {
        initial_speed = playerMovement.speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        playerMovement.goalPosition = other.bounds.center;
        playerMovement.tile = 3;
        playerMovement.giro = false;
        playerMovement.speed = 5.0f;
        switch (other.gameObject.tag)
        {
            case "RightTile": playerMovement.tile = 1;
                playerMovement.target = playerMovement.transform.position.z + 1;
                if (playerMovement.god_mode)
                {
                    playerMovement.girando = true;
                    playerMovement.giro = true;
                    playerMovement.aprox = true;
                    playerMovement.current = transform.position.z;
                }
                    break;
            case "LeftTile": playerMovement.tile = 2;
                playerMovement.target = playerMovement.transform.position.x + 1;
                if (playerMovement.god_mode)
                {
                    playerMovement.girando = true;
                    playerMovement.giro = true;
                    playerMovement.aprox = true;
                    playerMovement.current = transform.position.z;
                }
                break;
            case "BasicTile": playerMovement.tile = 3;
                break;
            case "SlowTile": if (!playerMovement.god_mode) playerMovement.speed -= 1;
                break;
            case "Trap": if (!playerMovement.god_mode) playerMovement.muerte = 1;
                break;
            case "Trap2": if (!playerMovement.god_mode) playerMovement.muerte = 2;
                break;
            case "TileSalto": playerMovement.tile = 3;
                if (playerMovement.god_mode) playerMovement.auto_salto = true;
                break;
            case "TileSalto2":
                playerMovement.tile = 4;
                if (playerMovement.god_mode) playerMovement.auto_salto = true;
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SlowTile")) if (playerMovement.speed == initial_speed && !playerMovement.god_mode) playerMovement.speed -= 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
            playerMovement.jump = 0;
            playerMovement.is_grounded = true;
         
    }

}
