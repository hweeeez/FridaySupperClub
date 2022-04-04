using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    private GameObject winner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Player").Length < 2)
        {
            print("EndGame");
            winner = GameObject.FindGameObjectWithTag("Player");
            print(winner.name);

        }
    }
}
