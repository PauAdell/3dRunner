using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteTrigger : MonoBehaviour
{
    public MeteoriteMovement meteoriteMovement;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
         if (other.CompareTag("Player")) {
            meteoriteMovement.arrancar = true;
            playerMovement.tile = 3;
            meteoriteMovement.target = playerMovement.transform.position;
             meteoriteMovement.target.y = 1;
        } 

    }
}
