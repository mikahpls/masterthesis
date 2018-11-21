using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInformationLoader : MonoBehaviour
{
    public Text Name, Information;
    public Image Image;
    public string currentURL;

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
                return;
            }
        }
        Debug.Log("No god with name: " + name + " found in Resources/information.txt");
    }

    private Sprite LoadImageFromResources(string path)
    {
        var sprite = Resources.Load<Sprite>(path);

        if (sprite == null)
        {
            Debug.Log("No Image found in Resources at path: " + path + " found.");
        }

        return sprite;
    }

    public void OpenBrowser()
    {
        Application.OpenURL(currentURL);
    }
}

[Serializable]
public class InformationText
{
    public string Name;
    public string Information;
    public string ImageName;
    public string URL;
}