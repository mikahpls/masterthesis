using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInformationLoader : MonoBehaviour
{
    public Text Name, Information;
    public Image Image;

    private static InformationText[] _informationTextArray;

    public void LoadInformation(string name)
    {
        TextAsset file = Resources.Load("information") as TextAsset;
        string jsonString = file.ToString();
        _informationTextArray = JsonHelper.FromJson<InformationText>(jsonString);

        foreach (var i in _informationTextArray)
        {
            if (i.Name == name)
            {
                Name.text = i.Name;
                Information.text = i.Information;
                return;
            }
        }
        Debug.Log("No god with name: " + name + " found in information.txt");
    }
}

[Serializable]
public class InformationText
{
    public string Name;
    public string Information;
}