using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MolassesScript : MonoBehaviour
{
    bool hasplayed = false;
    AudioSource audioSource;
    public AudioClip warning, waterSplash;
    //Timer
    float timeRemaining = 1f; //in seconds
    bool timerIsRunning = false;
    public GameObject timerText;

    //Rising Water
    public GameObject molassesIntro;
    public GameObject water;
    float riseSpeed = 12f;
    Vector2 maxWaterHeight;
    bool isRising = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        timerIsRunning = true;
        maxWaterHeight = new Vector2(water.transform.position.x, -9.5f);
        water.transform.position = new Vector2(0, -36f);

        molassesIntro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsRunning)
        {

            if (timeRemaining <= 1.1f && !hasplayed)
            {
                hasplayed = true;
                audioSource.clip = warning;
                audioSource.PlayOneShot(warning);
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                audioSource.clip = waterSplash;
                audioSource.PlayOneShot(waterSplash);
                audioSource.loop = true;
                molassesIntro.SetActive(true);
                //Debug.Log("Game over!");
                timeRemaining = 0;
                timerIsRunning = false;
                StartCoroutine(WaterRise(transform, maxWaterHeight, riseSpeed));
            }

        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator WaterRise(Transform transform, Vector2 maxLevel, float timeToRise)
    {
        if (isRising)
        {
            yield break; ///exit if this is still running
        }
        isRising = true;

        var t = 0f;
        Vector2 startLevel = new Vector2(0, -30f);
        //water.transform.position;

        while (t <= 1f)
        {
            t += Time.deltaTime / timeToRise;
            water.transform.position = Vector2.Lerp(startLevel, maxLevel, t);
            yield return null;
        }
        audioSource.loop = false;
        isRising = false;
    }

}
