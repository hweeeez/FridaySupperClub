using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    string winner;
    private GameObject[] kpGO;
    private GameObject[] thGO;
    private GameObject[] rsGO;
    private GameObject[] mcGO;
    // Start is called before the first frame update
    void Start()
    {
        kpGO = GameObject.FindGameObjectsWithTag("KPWin");
        mcGO = GameObject.FindGameObjectsWithTag("MCWin");
        rsGO = GameObject.FindGameObjectsWithTag("RSWin");
        thGO = GameObject.FindGameObjectsWithTag("THWin");
        
        foreach (GameObject mc in mcGO)
        {
            mc.SetActive(false);
        }
        foreach (GameObject mc in kpGO)
        {
            mc.SetActive(false);
        }
        foreach (GameObject mc in thGO)
        {
            mc.SetActive(false);
        }
        foreach (GameObject mc in rsGO)
        {
            mc.SetActive(false);
        }
        winner = PlayerPrefs.GetString("Winner");
    }

    // Update is called once per frame
    void Update()
    {
        if (winner.Contains("Konpei"))
        {
            foreach (GameObject obj in kpGO)
            {
                obj.SetActive(true);
            }
        }
        else if (winner.Contains("TangHulu"))
        {
            foreach (GameObject obj in thGO)
            {
                obj.SetActive(true);
            }
        }
        else if (winner.Contains("RockSugar"))
        {
            foreach (GameObject obj in rsGO)
            {
                obj.SetActive(true);
            }
        }
        else if (winner.Contains("Mac"))
        {
            print("macwon");

            foreach (GameObject obj in mcGO)
            {
                obj.SetActive(true);
                print(obj.name);
            }
        }
    }
}
