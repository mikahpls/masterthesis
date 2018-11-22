using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Material OpaqueMat, HiddenMat;

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

