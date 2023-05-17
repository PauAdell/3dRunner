using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Texture stepMaterial;
    private void OnTriggerEnter(Collider other)
    {
        playerMovement.tile = 3;
        playerMovement.giro = false;
        playerMovement.speed = 3.0f;
        playerMovement.desactivar_giro = false;
        playerMovement.desactivado = false;
        switch (other.gameObject.tag)
        {
            case "RightTile": playerMovement.tile = 1;
                break;
            case "LeftTile": playerMovement.tile = 2;
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

    private void OnTriggerStay(Collider other)
    {
        if (playerMovement.canviotex && (other.gameObject.tag == "RightTile" || other.gameObject.tag == "LeftTile"))
        {
            other.gameObject.GetComponent<Renderer>().material.mainTexture = stepMaterial;
            playerMovement.canviotex = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            playerMovement.jump = 0;
            playerMovement.is_grounded = true;
         
    }

}
