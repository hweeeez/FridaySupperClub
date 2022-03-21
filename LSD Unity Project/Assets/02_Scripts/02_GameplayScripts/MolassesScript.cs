using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MolassesScript : MonoBehaviour
{

    //Timer
    float timeRemaining = 5; //5 minutes = 300 seconds
    bool timerIsRunning = false;
    public GameObject timerText;

    //Rising Water
    public GameObject molassesIntro;
    public GameObject water;
    float riseSpeed = 12.5f;
    Vector2 maxWaterHeight;
    bool isRising = false;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        maxWaterHeight = new Vector2(water.transform.position.x, -9.8f);
        water.transform.position = new Vector2(0, -36f);

        molassesIntro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsRunning)
        {

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
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

        isRising = false;
    }

}
