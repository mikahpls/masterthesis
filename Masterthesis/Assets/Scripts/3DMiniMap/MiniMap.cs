using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Material OpaqueMat, HiddenMat;
    public Transform TargetPosition;

    void Start()
    {
        HighlightFloor(Floor.E);
    }

    public void HighlightFloor(Floor floor)
    {
        //setting all minimap materials to hidden material
        var rendererList = transform.GetComponentsInChildren<MeshRenderer>(true).ToList().Where(t => t.tag == "MinimapElement");
        foreach (var r in rendererList)
        {
            ChangeMaterial(r, HiddenMat);
        }

        //for this to work, Floor enum types have to have the same names as the minimap prefabs for the different floors
        var transformList = transform.GetComponentsInChildren<Transform>(true).ToList().Where(t => t.name == floor.ToString());
        foreach (var tr in transformList)
        {
            rendererList = tr.GetComponentsInChildren<MeshRenderer>(true).ToList().Where(t => t.tag == "MinimapElement");
            foreach (var r in rendererList)
            {
                ChangeMaterial(r, OpaqueMat);
            }
        }
    }

    //function with int parameter for button onclick event..
    public void HighlightFloor(int floor)
    {
        if (floor == 0)
        {
            HighlightFloor(Floor.E);
        }
        else if (floor == 1)
        {
            HighlightFloor(Floor.F1);
        }
        else if (floor == 2)
        {
            HighlightFloor(Floor.F2);
        }
        else
        {
            Debug.Log("Invalid floor number: " + floor + ". Try 0 ,1 or 2.");
        }
    }

    public void SetTargetPosition(Vector3 pos)
    {
        TargetPosition.localPosition = pos;
    }

    private void ChangeMaterial(MeshRenderer r, Material m)
    {
        var materials = r.materials;
        materials[0] = m;
        r.materials = materials;
    }
}

public enum Floor
{
    E,
    F1,
    F2
}

