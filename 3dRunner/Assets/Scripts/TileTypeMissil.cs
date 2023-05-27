using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTypeMissil : MonoBehaviour
{

    public MisilMovement misilMovement;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        misilMovement.goalPosition = other.bounds.center;
        misilMovement.giro = false;
        switch (other.gameObject.tag)
        {
            case "RightTile":
                misilMovement.tile = 1;
                misilMovement.target = misilMovement.transform.position.z + 1;
                misilMovement.girando = true;
                misilMovement.giro = true;
                misilMovement.aprox = true;
                misilMovement.current = transform.position.z;
                break;
            case "LeftTile":
                misilMovement.tile = 2;
                misilMovement.target = misilMovement.transform.position.x + 1;
                misilMovement.girando = true;
                misilMovement.giro = true;
                misilMovement.aprox = true;
                misilMovement.current = transform.position.z;
                break;
        }
    }
}
