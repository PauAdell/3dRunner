using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Management : MonoBehaviour
{
    public int monedas;
    public int topScore;
    public Text txtgiros;
    public Text txtmonedas;

    public PlayerMovement playerMovement;

    bool playing;
    // Start is called before the first frame update
    void Start()
    {
        monedas = topScore = 0;
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing) {
            txtgiros.text = playerMovement.getNumGiros().ToString();
            txtmonedas.text = monedas.ToString();
        }
        EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moneda")
        {
            other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            monedas += 1;
        }
    }

    public void EndGame() {
        if (!playerMovement.start)
        {
            monedas = 0;
        }
        if (playerMovement.muerte == 5)
        {
            if (monedas > topScore) topScore = monedas;
        }
    }
}
