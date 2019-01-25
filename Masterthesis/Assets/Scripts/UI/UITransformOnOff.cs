using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransformOnOff : MonoBehaviour
{
    //List to make it possible to swap multiple transforms to active
    public List<Transform> TransformList = new List<Transform>();

    public void TransformOnOff()
    {
        //swap transform from active to unactive and vise versa
        foreach (var t in TransformList)
        {
            t.gameObject.SetActive(!t.gameObject.activeSelf);
        }
    }

}
