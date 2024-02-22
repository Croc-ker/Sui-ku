using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBoardPowerUp : MonoBehaviour
{
    [SerializeField] BoolVariable inUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Dropper.shapeMergeList.Count > 0)
        {
            foreach (var shape in Dropper.shapeMergeList)
            {
                Destroy(shape);
            }
            Dropper.shapeMergeList.Clear();
        }
    }
}
