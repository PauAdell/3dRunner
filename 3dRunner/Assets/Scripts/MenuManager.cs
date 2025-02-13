using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource menuMusic;
    public void Start()
    {
        menuMusic.volume = 0.5f;
        menuMusic.Play();
    }
    public void canviEscena(string nomEscena) {
        SceneManager.LoadScene(nomEscena);
    }

    // Update is called once per frame
    public void QuitGame() {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Screenmanager Resolution Height");
        PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
        PlayerPrefs.DeleteKey("Screenmanager Is Fullscreen mode");
    }
}
