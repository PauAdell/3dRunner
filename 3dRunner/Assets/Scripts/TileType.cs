using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private float initial_speed;
    private bool canvitext;
    public Material novaTextura;
    public ParticleSystem explosion;

    void Start()
    {
        initial_speed = playerMovement.speed;
        canvitext = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerMovement.muerte == 0)
        {
            playerMovement.goalPosition = other.bounds.center;
            if (!playerMovement.girando) playerMovement.tile = 3;
            playerMovement.giro = false;
            if (playerMovement.is_grounded) playerMovement.speed = initial_speed;
            switch (other.gameObject.tag)
            {
                case "RightTile":
                    canvitext = true;
                    playerMovement.tile = 1;
                    playerMovement.target = playerMovement.transform.position.z + 1;
                    if (playerMovement.god_mode)
                    {
                        playerMovement.girando = true;
                        playerMovement.giro = true;
                        playerMovement.aprox = true;
                        playerMovement.current = transform.position.z + 0.15f;
                        playerMovement.timer_god = 25;
                    }
                    break;
                case "LeftTile":
                    canvitext = true;
                    playerMovement.tile = 2;
                    playerMovement.target = playerMovement.transform.position.x + 1;
                    if (playerMovement.god_mode)
                    {
                        playerMovement.girando = true;
                        playerMovement.giro = true;
                        playerMovement.aprox = true;
                        playerMovement.current = transform.position.x + 0.15f;
                        playerMovement.timer_god = 25;
                    }
                    break;
                case "BasicTile":
                    if (playerMovement.transform.position.y + 0.3 < playerMovement.pos_ini.y) playerMovement.salto_corto = true;
                    break;
                case "SlowTile":
                    if (!playerMovement.god_mode) playerMovement.speed -= 2;
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
                        Instantiate(explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
                        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        other.gameObject.GetComponent<ParticleSystem>().Stop();
                        playerMovement.in_anim = 0;
                    }
                        break;
                case "TileSalto":
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
                case "Victory":
                    playerMovement.victory = true;
                    playerMovement.in_anim = 300;
                    playerMovement.speed = 0;
                    Vector3 tp = new Vector3(176, -1, 197);
                    playerMovement.transform.position = tp;
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LeftTile" || other.tag == "RightTile") {

            if (playerMovement.time_to_gir != 0 && canvitext) {
                other.gameObject.GetComponent<Renderer>().material = novaTextura;
                canvitext = false;
            }
        }
        if (other.CompareTag("SlowTile")) if (playerMovement.speed == initial_speed && !playerMovement.god_mode) playerMovement.speed -= 2;
        else if (other.CompareTag("Trap")) if (!playerMovement.god_mode && playerMovement.muerte == 0)
            {
                playerMovement.muerte = 1;
                playerMovement.in_anim = 0;
            }
        else if (other.CompareTag("Trap2")) if (!playerMovement.god_mode && playerMovement.muerte == 0)
            {
                playerMovement.muerte = 2;
                Instantiate(explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
                playerMovement.in_anim = 0;
            }
        else if (other.CompareTag("BasicTile")) if (!playerMovement.girando) playerMovement.tile = 3;

    }
    private void OnCollisionEnter(Collision collision)
    {
        playerMovement.jump = 0;
        if (collision.gameObject.tag == "BasicTile" || collision.gameObject.tag == "RightTile" || collision.gameObject.tag == "LeftTile")
        {
            if (playerMovement.transform.position.y + 0.1 >= playerMovement.pos_ini.y && playerMovement.transform.position.y < 0.3) playerMovement.is_grounded = true;
        }
         
    }

}
