using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool jocParat = false;
    public static bool jugadormort = false;


    public GameObject menuPausa;
    public PlayerMovement player;
    public SoundEffects sounds;

    void Update()
    {
        if (!player.menu_victoria)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !jugadormort)
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
        sounds.stopMusic();
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        jocParat = false;
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}