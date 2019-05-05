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
        //DEBUG CODE
        //ModelTargetFound("Laokoon");
    }

    public void RegisterModelTarget(Transform t)
    {
        _modelTargetList.Add(t);
    }

    public void ModelTargetFound(string name)
    {
        //Make sure the string name on the customtrackableeventhandler is the same as the transform name of the root ui element
        UiMainPanelSwitcher.SwitchMainPanelTo(name);
    }

    public void ModelTargetLost(string name)
    {
        //special switch back rules
        if (name == "Laokoon")
        {
            return;
        }

        UiMainPanelSwitcher.SwitchMainPanelTo("Erweiterte Realität");
    }
}
