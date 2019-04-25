using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInformationLoader : MonoBehaviour
{
    public MiniMap Minimap;
    public UIMainPanelSwitcher UIMainPanelSwitcher;

    public Text Name, Information;
    public Image Image;
    private string currentURL;
    private int currentTargetFloor;
    private Vector3 currentTargetVector;

    private static InformationText[] _informationTextArray;

    //Puts information from json file to the information screen and looks up the matching image + loads it as sprite
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
                Image.sprite = LoadImageFromResources("Images/Gods/" + i.ImageName);
                Image.preserveAspect = true;
                currentURL = i.URL;
                currentTargetFloor = int.Parse(i.TargetFloor);
                currentTargetVector = GetV3FromString(i.TargetVector);
                return;
            }
        }
        Debug.Log("No god with name: " + name + " found in Resources/information.txt");
    }

    public string[] GetDataAsStringArray(string name)
    {
        string[] array = new string[6];

        TextAsset file = Resources.Load("information") as TextAsset;
        string jsonString = file.ToString();
        _informationTextArray = JsonHelper.FromJson<InformationText>(jsonString);

        foreach (var i in _informationTextArray)
        {
            if (i.Name == name)
            {
                array[0] = i.Name;
                array[1] = i.Information;
                array[2] = i.ImageName;
                array[3] = i.URL;
                array[4] = i.TargetFloor;
                array[5] = i.TargetVector;
                return array;
            }
        }
        Debug.Log("No data with name: " + name + " found in Resources/information.txt");
        return null;
    }

    private Sprite LoadImageFromResources(string path)
    {
        var sprite = Resources.Load<Sprite>(path);

        if (sprite == null)
        {
            Debug.Log("No Image found in Resources at path: " + path);
        }

        return sprite;
    }

    //format: "a,b,c"
    private Vector3 GetV3FromString(string s)
    {
        var array = s.Split(',');
        if(array.Length != 3) Debug.Log("Error parsing strings to vector3, wrong format?");
        return new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
    }

    public void OpenBrowser()
    {
        Application.OpenURL(currentURL);
    }

    public void OpenMiniMap()
    {
        //ugly
        Minimap.HighlightFloor(currentTargetFloor);
        Minimap.SetTargetPosition(currentTargetVector);
        UIMainPanelSwitcher.SwitchMainPanelTo("Karte");
    }
}

[Serializable]
public class InformationText
{
    public string Name;
    public string Information;
    public string ImageName;
    public string URL;
    public string TargetFloor;
    public string TargetVector;
}