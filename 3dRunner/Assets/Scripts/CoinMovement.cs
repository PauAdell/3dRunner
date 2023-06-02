using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Vector3 _startPosition;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerMovement.start)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        transform.Rotate(new Vector3(0f,  2.5f, 0f));
        transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.time)/2f, 0.0f);
    }

}
