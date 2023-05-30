using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private bool menusonant;
    private bool jocsonant;
    public AudioSource jumpSound;
    public AudioSource menuMusic;
    public AudioSource playMusic;
    public AudioSource deathSound;
    // Start is called before the first frame update

    private void Start()
    {
        menusonant = false;
        jocsonant = false;
    }
    public void playDeathSound() {
        deathSound.Play();
    }
    public void playJumpSound()
    {
        jumpSound.Play();
    }

    public void playMenuMusic()
    {
        menuMusic.Play();
        menusonant = true;
    }

    public void playPlayMusic()
    {
        playMusic.Play();
        jocsonant = true;
    }

    public void stopMusic() {
        if (jocsonant) playMusic.Stop();
        if (menusonant) menuMusic.Stop();
    }
}
