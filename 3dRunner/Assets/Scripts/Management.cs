using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Management : MonoBehaviour
{
    public GameObject objgiros;
    public GameObject objmonedas;
    public int monedas;
    Text txtmonedas;
    Text txtgiros;

    public PlayerMovement playerMovement;

    private int top_score;
    bool playing;
    // Start is called before the first frame update
    void Start()
    {
        monedas = top_score = 0;
        playing = true;
        txtmonedas = objgiros.GetComponent<Text>();
        txtgiros = objmonedas.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing) {
            txtgiros.text = playerMovement.numgiros.ToString();
            txtmonedas.text = monedas.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moneda")  monedas += 1;
    }

    public void EndGame() {
        if (monedas > top_score) top_score = monedas;
        monedas = 0;
    }
}
