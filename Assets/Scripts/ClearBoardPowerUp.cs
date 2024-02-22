using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBoardPowerUp : MonoBehaviour
{
    [SerializeField] BoolVariable inUse;


    public void OnUse()
	{
		if (!inUse && Dropper.shapeMergeList.Count > 0)
		{
			foreach (var shape in Dropper.shapeMergeList)
			{
				Destroy(shape);
			}
			Dropper.shapeMergeList.Clear();
		}
	}
}
