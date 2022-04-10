using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXScript : MonoBehaviour
{

    private AudioSource audioSource;

    //UI buttons SFX
    public AudioClip playButton, pauseButton, backAndResume, submenu;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(playButton);
    }

    public void InGameMenuButtons()
    {
        audioSource.PlayOneShot(pauseButton);
    }

    public void BackAndResumeButton()
    {
        audioSource.PlayOneShot(backAndResume);
    }

    public void SubMenuButton()
    {
        audioSource.PlayOneShot(submenu);
    }
    
}
