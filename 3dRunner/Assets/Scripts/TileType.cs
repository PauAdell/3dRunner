using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        playerMovement.goalPosition = other.bounds.center;
        playerMovement.tile = 3;
        playerMovement.giro = false;
        playerMovement.speed = 3.0f;
        switch (other.gameObject.tag)
        {
            case "RightTile": playerMovement.tile = 1;
                playerMovement.target = playerMovement.transform.position.z + 1;
                //print(other.gameObject.transform.position.z);
                //print(other.bounds.min.z);
                break;
            case "LeftTile": playerMovement.tile = 2;
                playerMovement.target =  other.bounds.max.x - other.bounds.min.x;
                break;
            case "BasicTile": playerMovement.tile = 3;
                break;
            case "SlowTile": playerMovement.speed -= 1;
                break;
            case "Trap": playerMovement.muerte = 1;
                break;
            case "Trap2": playerMovement.muerte = 2;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
            playerMovement.jump = 0;
            playerMovement.is_grounded = true;
         
    }

}
