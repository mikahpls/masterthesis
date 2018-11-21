using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingAlphaValueScript : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Color _startColor;

	void Start ()
	{
	    _renderer = GetComponent<MeshRenderer>();
        _startColor = _renderer.material.color;
    }
	
	void Update ()
	{
	    ChangeAlphaValueOfMaterial();
	}

    private void ChangeAlphaValueOfMaterial()
    {
        var modifier = (Mathf.Sin(Time.time * 3) + 1) / 5;
        _renderer.material.color = new Color(_startColor.r, _startColor.g, _startColor.b, _startColor.a - modifier);
    }
}
