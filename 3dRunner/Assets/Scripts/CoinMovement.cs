using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Vector3 _startPosition;
    public PlayerMovement playerMovement;
    public bool vanishing;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        vanishing = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerMovement.start)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            vanishing = false;
        }
        transform.Rotate(new Vector3(0f,  2.5f, 0f));
        if (!vanishing) transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.time)/2f, 0.0f);
        if (vanishing) transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        if (transform.position.y >= _startPosition.y + 3) gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    public void setVanishing()
    {
        vanishing = true;
    }

}
