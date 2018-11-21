using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidLogger : MonoBehaviour
{
    private List<string> _logList = new List<string>();
    private int _maxLineCount = 30;
    private string _debugString = "";

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 1000, 1000), _debugString); //disabled for demo purposes
    }

    public void Log(string log)
    {
        _debugString = "";
        if (_logList.Count > _maxLineCount)
        {
            _logList.RemoveAt(0);
        }
        _logList.Add(log + "\n");

        foreach (var str in _logList)
        {
            _debugString += str;
        }
    }
}
