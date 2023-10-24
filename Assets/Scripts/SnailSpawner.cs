using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailSpawner : MonoBehaviour
{
    public float spawnTimer1= 10;
    public GameObject Snail1;
    private bool TimerBool1 = false;
    public int MaxEntityLimit = 20;
    private int CurrentEntityCount = 0; 



    void Update()
    {
        if (!TimerBool1 && CurrentEntityCount < MaxEntityLimit)
        {
            TimerBool1 = true;
            Instantiate(Snail1);
            CurrentEntityCount++;
            StartCoroutine(DelaySnail1());
        }
    }

    public IEnumerator DelaySnail1()
    {
        yield return new WaitForSeconds(spawnTimer1);
        TimerBool1 = false;
    }

}
