using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIMainPanelSwitcher : MonoBehaviour
{
    public UIInformationLoader UIInformationLoader;

    public Text UITopMenuText;

    public void SwitchMainPanelTo(string name)
    {
        var transformList = transform.GetComponentsInChildren<Transform>(true).ToList().Where(t => t.tag == "MainPanel");
        foreach (var t in transformList)
        {
            t.gameObject.SetActive(false);
        }

        transformList = transform.GetComponentsInChildren<Transform>(true).ToList().Where(t => t.name == name);
        if (transformList.Count() == 0 && transformList.Count() >= 2)
        {
            Debug.Log("No or multiple MainPanel-tagged Objects with name: " + name + " found.");
            return;
        }

        transformList.First().gameObject.SetActive(true);
        UITopMenuText.text = name;
    }

    public void SwitchMainPanelToInformation(string godString)
    {
        SwitchMainPanelTo("Information");
        UIInformationLoader.LoadInformation(godString);
    }
}
