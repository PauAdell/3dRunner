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
        if (playerMovement.muerte == 0)
        {
            playerMovement.goalPosition = other.bounds.center;
            playerMovement.tile = 3;
            playerMovement.giro = false;
            if (playerMovement.is_grounded) playerMovement.speed = initial_speed;
            switch (other.gameObject.tag)
            {
                case "RightTile":
                    playerMovement.tile = 1;
                    playerMovement.target = playerMovement.transform.position.z + 1;
                    if (playerMovement.god_mode)
                    {
                        playerMovement.girando = true;
                        playerMovement.giro = true;
                        playerMovement.aprox = true;
                        playerMovement.current = transform.position.z;
                    }
                    break;
                case "LeftTile":
                    playerMovement.tile = 2;
                    playerMovement.target = playerMovement.transform.position.x + 1;
                    if (playerMovement.god_mode)
                    {
                        playerMovement.girando = true;
                        playerMovement.giro = true;
                        playerMovement.aprox = true;
                        playerMovement.current = transform.position.z;
                    }
                    break;
                case "BasicTile":
                    playerMovement.tile = 3;
                    if (playerMovement.transform.position.y + 0.3 < playerMovement.pos_ini.y) playerMovement.salto_corto = true;
                    break;
                case "SlowTile":
                    if (!playerMovement.god_mode) playerMovement.speed -= 1;
                    break;
                case "Trap":
                    if (!playerMovement.god_mode)
                    {
                        playerMovement.muerte = 1;
                        playerMovement.in_anim = 0;
                    }
                    break;
                case "Trap2":
                    if (!playerMovement.god_mode)
                    {
                        playerMovement.muerte = 2;
                        playerMovement.in_anim = 0;
                    }
                        break;
                case "TileSalto":
                    playerMovement.tile = 3;
                    if (playerMovement.god_mode) playerMovement.auto_salto = true;
                    break;
                case "TileSalto2":
                    playerMovement.tile = 4;
                    if (playerMovement.god_mode) playerMovement.auto_salto = true;
                    break;
                case "Void":
                    playerMovement.muerte = 5;
                    gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                    playerMovement.playerRb.isKinematic = true;
                    break;         
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SlowTile")) if (playerMovement.speed == initial_speed && !playerMovement.god_mode) playerMovement.speed -= 1;
        if (other.CompareTag("Trap")) if (!playerMovement.god_mode && playerMovement.muerte == 0)
            {
                playerMovement.muerte = 1;
                playerMovement.in_anim = 0;
            }
        if (other.CompareTag("Trap2")) if (!playerMovement.god_mode && playerMovement.muerte == 0)
            {
                playerMovement.muerte = 2;
                playerMovement.in_anim = 0;
            }

    }
    private void OnCollisionEnter(Collision collision)
    {
        playerMovement.jump = 0;
        if (collision.gameObject.tag == "BasicTile" || collision.gameObject.tag == "RightTile" || collision.gameObject.tag == "LeftTile")
        {
            if (playerMovement.transform.position.y + 0.1 >= playerMovement.pos_ini.y) playerMovement.is_grounded = true;
        }
         
    }

}
