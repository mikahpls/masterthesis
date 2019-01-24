using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTargetCollection : MonoBehaviour
{
    public UIMainPanelSwitcher UiMainPanelSwitcher;

    private List<Transform> _modelTargetList = new List<Transform>();

    void Start()
    {
        if (UiMainPanelSwitcher == null) Debug.Log("UIMainPanelSwitcher in ModelTargetCollection is null.");
    }

    public void RegisterModelTarget(Transform t)
    {
        _modelTargetList.Add(t);
    }

    public void ModelTargetFound(string name)
    {
        
    }

    public void ModelTargetLost(string name)
    {
        
    }
}
