using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MultiplierPowerUp : MonoBehaviour
{
    [SerializeField] IntVariable multiplier;
    [SerializeField] BoolVariable inUse;
    [SerializeField] IntEvent UseCost;
    [SerializeField] int cost;
    [SerializeField] int value;
    [SerializeField] int time;

    public void OnUse()
    {
        if(!inUse)
        {
            UseCost?.RaiseEvent(cost);
            StartCoroutine(ScoreMultiplier());
        }
    }

	IEnumerator ScoreMultiplier()
    {
        inUse.value = true;
        multiplier.value = value;
		Debug.Log("Multiplier: " + multiplier.value);
		yield return new WaitForSeconds(time);
        multiplier.value = 1;
		Debug.Log("Multiplier: " + multiplier.value);
		inUse.value = false;
		StopCoroutine(ScoreMultiplier());
    }
}
