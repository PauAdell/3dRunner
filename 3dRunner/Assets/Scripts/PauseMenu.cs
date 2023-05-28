using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool jocParat = false;
    public GameObject player;

    public GameObject menuPausa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jocParat)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        jocParat = false;
    }
    void Pause()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        jocParat = true;
    }

    public void canviEscena(string nomEscena)
    {
        SceneManager.LoadScene(nomEscena);
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        jocParat = false;
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}