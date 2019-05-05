using System.Collections.Generic;
using UnityEngine;

//testing script, currently not in use
public class Rotatable : MonoBehaviour
{
    private AndroidLogger _logger;
    private List<float> _compassValues;
    private float _smoothTrueHeading;

    private float _xRot, _dist, _lastDist;
    private bool _touchedLastFrame;

    private float _timer;

    void Start()
    {
        _logger = GameObject.Find("AndroidLogger").GetComponent<AndroidLogger>();

        _compassValues = new List<float>();
        Input.compass.enabled = true;
    }

    void Update()
    {
        SmoothCompassValues();
        InputHandling();
        RotateModel();
        //RotateModel2();

        _timer += Time.deltaTime;
        if (_timer > 0.2f)
        {
            //_logger.Log(_smoothTrueHeading.ToString());
            _timer = 0;
        }
    }

    private void SmoothCompassValues()
    {
        if (_compassValues.Count > 100)
        {
            _compassValues.RemoveAt(0);
        }
        _compassValues.Add(Input.compass.trueHeading);

        float temp = 0;
        foreach (var value in _compassValues)
        {
            temp += value;
        }
        temp /= _compassValues.Count;
        _smoothTrueHeading = temp;
    }

    private void InputHandling()
    {
        //if screen not touched
        if (Input.touchCount == 0)
        {
            _touchedLastFrame = false;
            _lastDist = _dist = 0;
        }

        //if screen touched
        if (Input.touchCount == 1)
        {
            if (_touchedLastFrame) _xRot -= Input.GetAxis("Mouse X");
            _touchedLastFrame = true;
        }

        //scaling
        //if (Input.touchCount == 2)
        //{
        //    var p1 = Input.touches[0].position;
        //    var p2 = Input.touches[1].position;
        //    _dist = Vector2.Distance(p1, p2);

        //    if (_lastDist != 0)
        //    {
        //        var scaling = _lastDist - _dist;
        //        ScaleModel(scaling);
        //    }
        //    _lastDist = _dist;
        //}
    }

    private void RotateModel()
    {
        var curRot = transform.rotation;
        var futRot = Quaternion.Euler(0, _xRot, 0);
        transform.rotation = Quaternion.Lerp(curRot, futRot, Time.deltaTime * 10);
    }

    private void RotateModel2()
    {
        var curRot = transform.rotation;
        var futRot = Quaternion.Euler(0, -_smoothTrueHeading, 0);
        transform.rotation = Quaternion.Lerp(curRot, futRot, Time.deltaTime * 10);
    }

    //private void ScaleModel(float scaling)
    //{
    //    scaling /= -1000;
    //    var scale = transform.localScale;
    //    if (scale.x + scaling < 0.01) return;
    //    transform.localScale = new Vector3(scale.x + scaling, scale.y + scaling, scale.z + scaling);
    //}
}

