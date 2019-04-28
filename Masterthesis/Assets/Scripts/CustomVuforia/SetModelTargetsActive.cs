using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetModelTargetsActive : MonoBehaviour {

    public List<GameObject> ModelTargetList = new List<GameObject>();

	//laokoon 0
    //aphaia 1
    public void SetModelToActive(int i)
    {
        foreach(var obj in ModelTargetList)
        {
            obj.SetActive(false);
        }

        if(i == 0)
        {
            ModelTargetList[0].SetActive(true);
        }
        else if(i == 1)
        {
            ModelTargetList[1].SetActive(true);
        }
    }
}
