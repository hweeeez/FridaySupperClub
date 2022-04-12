using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shortBeep, longBeep;
    public GameObject GameManager;
    public GameObject countDown;

    private void Start()
    {
        StartCoroutine(StartDelay());
        audioSource = GetComponent<AudioSource>();
    }


    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3.4f;
        while (Time.realtimeSinceStartup < pauseTime)
        { yield return 0; }
        GameManager.SetActive(true);
        Time.timeScale = 1;

        countDown.SetActive(false);
    }
    public void ShortBeep()
    {
        audioSource.clip = shortBeep;
        audioSource.PlayOneShot(shortBeep);
    }
    public void LongBeep()
    {
        audioSource.clip = longBeep;
        audioSource.PlayOneShot(longBeep);
    }
}

