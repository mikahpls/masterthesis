using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeUpdate : MonoBehaviour
{
    public Text UITopMenuTimeText;

    private float _cooldown = 70;

	void Update ()
	{
	    _cooldown += Time.deltaTime;
	    if (_cooldown > 60)
	    {
	        _cooldown = 0;
	        UITopMenuTimeText.text = GetFormatedTimeString();
	    }
	}

    private string GetFormatedTimeString()
    {
        var timenow = System.DateTime.Now;
        string h = "";
        var hours = timenow.Hour;
        if (hours < 10)
        {
            h = "0" + hours;
        }
        else
        {
            h = hours.ToString();
        }
        string m = "";
        var minutes = timenow.Minute;
        if (minutes < 10)
        {
            m = "0" + minutes;
        }
        else
        {
            m = minutes.ToString();
        }
        return h + ":" + m;
    }
}
