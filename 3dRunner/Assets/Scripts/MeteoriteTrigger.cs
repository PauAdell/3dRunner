using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteTrigger : MonoBehaviour
{
    public MeteoriteMovement meteoriteMovement;
    public PlayerMovement playerMovement;
    private int tempsdeWarning;
    public FloatingWarining warning;
    private bool resetejat;
    public SoundEffects sound;

    // Start is called before the first frame update
    void Start()
    {
        tempsdeWarning = 150*2;
        resetejat = true;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
         if (other.CompareTag("Player")) {
            meteoriteMovement.arrancar = true;
            meteoriteMovement.target = playerMovement.transform.position;
            meteoriteMovement.target.y = 1;
            warning.makeWarnAppear();
            sound.playWarining();
        } 
        
    }
    void Update() {
        if (meteoriteMovement.arrancar) {
            tempsdeWarning -= 1;
        } else {
            if (!resetejat) {
                tempsdeWarning = 250*2;
                resetejat = true;
            }
        }
        if (tempsdeWarning == 0) {
            warning.removeWarining();
            resetejat = false;
        }
    }
}
