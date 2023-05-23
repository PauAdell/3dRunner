using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    private int monedas;
    private int top_score;
    // Start is called before the first frame update
    void Start()
    {
        monedas = top_score = 0;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("moneda"))  {
            monedas += 1;
            other.gameObject.SetActive(false);
    }
    }

    public void EndGame() {
        if (monedas > top_score) top_score = monedas;
        monedas = 0;
    }
}
