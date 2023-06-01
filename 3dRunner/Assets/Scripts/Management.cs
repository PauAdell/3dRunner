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
    public Text txtTopScore;
    public Text txtTopScore2;

    public PlayerMovement playerMovement;
    public SoundEffects sounds;

    bool playing;
    // Start is called before the first frame update
    void Start()
    {
        monedas = topScore = 0;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing) {
            txtgiros.text = playerMovement.getNumGiros().ToString();
            txtmonedas.text = monedas.ToString();
            txtTopScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            txtTopScore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "moneda")
        {
            other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            monedas += 1;
            sounds.playCoinSound();
            if (monedas > topScore)
            {
                topScore = monedas;
                PlayerPrefs.SetInt("HighScore", topScore);
            }
        }
    }

    public void EndGame() {
        if (!playerMovement.start)
        {
            monedas = 0;
        }
        if (playerMovement.muerte == 5)
        {
            if (monedas > topScore) {
                topScore = monedas;
                PlayerPrefs.SetInt("HighScore", topScore);
            }
        }
    }
}
