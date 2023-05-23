using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void canviEscena(string nomEscena) {
        SceneManager.LoadScene(nomEscena);
    }

    // Update is called once per frame
    public void QuitGame() {
        Application.Quit();
    }
}
