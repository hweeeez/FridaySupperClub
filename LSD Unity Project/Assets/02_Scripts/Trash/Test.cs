using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("VicScreenPoints");
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        transform.position = currentPoint.transform.position;
        print(currentPoint.name);
    }

}
