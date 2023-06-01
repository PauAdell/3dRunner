using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    private bool menusonant;
    private bool jocsonant;
    public AudioSource jumpSound;
    public AudioSource menuMusic;
    public AudioSource playMusic;
    [SerializeField] AudioSource deathSound;

    public Slider volumeSlider;
    // Start is called before the first frame update

    private void Start()
    {
        menusonant = false;
        jocsonant = false;
        AudioListener.volume = volumeSlider.value;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else {
            Load();
        }

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

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
