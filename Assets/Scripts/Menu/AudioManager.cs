using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//! This class manages the background audio sytem, enabling or disabling it
public class AudioManager : MonoBehaviour {

    public Sprite musicOn;
    public Sprite musicOff;
    private Button soundButton;
    private AudioSource source;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("soundButton"))
            soundButton = GameObject.FindGameObjectWithTag("soundButton").GetComponent<Button>();

        source = GameObject.FindGameObjectWithTag("musicPlayer").GetComponent<AudioSource>();

        source.Play();
        if (PlayerPrefs.GetString("sound") == "on")
        {
            ChangeButtonSprite(true);
            PlayerPrefs.SetString("sound", "on");
        }
        else
        {
            source.Pause();
            ChangeButtonSprite(false);
            PlayerPrefs.SetString("sound", "off");
        }           
    }

    public void ToggleSound()
    {
        if (source.isPlaying)
        {
            source.Pause();
            ChangeButtonSprite(false);
            PlayerPrefs.SetString("sound", "off");
        }
        else
        {
            ChangeButtonSprite(true);
            PlayerPrefs.SetString("sound", "on");

            if (!source.isPlaying)
                source.Play();
            else
                source.UnPause();
        }      
    }

    private void ChangeButtonSprite(bool isMusicPlaying)
    {
        if (soundButton)
        {
            if (isMusicPlaying)
                soundButton.image.sprite = musicOn;
            else
                soundButton.image.sprite = musicOff;
        }
    }
}
