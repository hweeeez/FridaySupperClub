using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    string winner;
    public GameObject winNer;
    private VictoryScreen vcSc;
    public GameObject kp;
    public GameObject th;
    public GameObject rs;
    public GameObject mc;
    private GameObject[] kpGO;
    private GameObject[] thGO;
    private GameObject[] rsGO;
    private GameObject[] mcGO;
    // Start is called before the first frame update
    void Start()
    {
        //vcSc = GameObject.Find("VictoryScreen").GetComponent<VictoryScreen>();
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
            Animator kpanim = kp.GetComponent<Animator>();
            kpanim.SetBool("Win", true);
            foreach (GameObject obj in kpGO)
            {
                obj.SetActive(true);
            }
        }
        else if (winner.Contains("TangHulu"))
        {
            Animator thanim = th.GetComponent<Animator>();
            thanim.SetBool("Win", true);
            foreach (GameObject obj in thGO)
            {
                obj.SetActive(true);
            }
        }
        else if (winner.Contains("RockSugar"))
        {
            Animator rsanim = rs.GetComponent<Animator>();
            rsanim.SetBool("Win", true);
            foreach (GameObject obj in rsGO)
            {
                obj.SetActive(true);
            }
        }
        else if (winner.Contains("Mac"))
        {
            Animator mcanim = mc.GetComponent<Animator>();
            mcanim.SetBool("Win", true);
            print("macwon");

            foreach (GameObject obj in mcGO)
            {
                obj.SetActive(true);
                print(obj.name);
            }
        }
    }
}
