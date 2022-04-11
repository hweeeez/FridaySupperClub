using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
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
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PlayableTest01") && this.transform.GetChild(0).gameObject != null)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
    }
    public void PlayButton()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = playButton;
        audioSource.PlayOneShot(playButton);
    }

    public void InGameMenuButtons()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = pauseButton;

        audioSource.PlayOneShot(pauseButton);
    }

    public void BackAndResumeButton()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = backAndResume;
        audioSource.PlayOneShot(backAndResume);
    }

    public void SubMenuButton()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = submenu;
        audioSource.PlayOneShot(submenu);
    }

}
