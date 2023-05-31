using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class topScoreManager : MonoBehaviour
{
    public Text txtTopScore;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        txtTopScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
