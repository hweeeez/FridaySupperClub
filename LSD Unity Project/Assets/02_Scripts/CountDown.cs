using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    public GameObject countDown;
    public int countdownTime;
    public Text countdownDisplay;
    private void Start()
    {
        StartCoroutine(StartDelay());
        // StartCoroutine(CountdownToStart());
    }

    /* IEnumerator CountdownToStart()
     {
         while (countdownTime > 0)
         {
             countdownDisplay.text = countdownTime.ToString();
             yield return new WaitForSeconds(1f);
             countdownTime--;
         }
         countdownDisplay.text = "GO!";
         yield return new WaitForSeconds(1f);

     }*/
    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

