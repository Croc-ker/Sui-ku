using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBoardPowerUp : MonoBehaviour
{
    [SerializeField] BoolVariable inUse;
    [SerializeField] IntEvent UseCost;
    [SerializeField] int cost;

    public void OnUse()
	{
		if (!inUse && Dropper.shapesInPlayList.Count > 0)
		{
			UseCost?.RaiseEvent(cost);
			foreach (var shape in Dropper.shapesInPlayList)
			{
				Destroy(shape);

				Debug.Log("Shape destroyed");
			}
			Dropper.shapesInPlayList.Clear();
		}
	}
}
