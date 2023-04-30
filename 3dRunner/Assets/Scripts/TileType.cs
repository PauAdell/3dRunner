using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightTile")
        {
            playerMovement.tile = 1;
        }
        else if (other.gameObject.name == "LeftTile")
        {
            playerMovement.tile = 2;
        }
        else
        {
            playerMovement.tile = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        playerMovement.tile = 3;
        playerMovement.giro = false;
    }
}
