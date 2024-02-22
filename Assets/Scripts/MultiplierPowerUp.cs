using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierPowerUp : MonoBehaviour
{
    [SerializeField] IntVariable multiplier;
    [SerializeField] BoolVariable inUse;
    [SerializeField] int value;
    [SerializeField] int time;


    void Start()
    {
        multiplier.value = 1;
    }


    void Update()
    {
        if(!inUse) StartCoroutine(ScoreMultiplier());
    }

    IEnumerator ScoreMultiplier()
    {
        multiplier.value = value;
        yield return new WaitForSeconds(time);
        multiplier.value = 1;
        StopCoroutine(ScoreMultiplier());
    }
}
