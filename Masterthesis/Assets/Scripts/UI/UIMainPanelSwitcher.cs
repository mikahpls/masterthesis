using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIMainPanelSwitcher : MonoBehaviour
{
    public Text UITopMenuText;

    public void SwitchMainPanelTo(string name)
    {
        var list = transform.GetComponentsInChildren<Transform>(true).ToList().Where(t => t.tag == "MainPanel");
        foreach (var t in list)
        {
            t.gameObject.SetActive(false);
        }

        list = transform.GetComponentsInChildren<Transform>(true).ToList().Where(t => t.name == name);
        if (list.Count() == 0 && list.Count() >= 2)
        {
            Debug.Log("No or multiple MainPanel-tagged Objects with name: " + name + " found.");
            return;
        }

        list.First().gameObject.SetActive(true);
        UITopMenuText.text = name;
    }

}
