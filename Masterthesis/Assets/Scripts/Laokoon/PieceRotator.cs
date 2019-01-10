
using System;
using UnityEngine;

public class PieceRotator : MonoBehaviour
{
    private float _xRot, _dist, _lastDist;
    private bool _touchedLastFrame;

    void Update()
    {
        InputHandling();
        RotateModel();
    }

    private void InputHandling()
    {
        //Debug.Log(Input.GetAxis("Mouse X"));
        //if screen not touched
        if (Input.touchCount == 0 || !Input.GetMouseButtonDown(0))
        {
            _touchedLastFrame = false;
            _lastDist = _dist = 0;
        }

        //if screen touched
        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
        {
            if (_touchedLastFrame) _xRot -= Input.GetAxis("Mouse X");
            _touchedLastFrame = true;
        }

        //scaling
        if (Input.touchCount == 2)
        {
            var p1 = Input.touches[0].position;
            var p2 = Input.touches[1].position;
            _dist = Vector2.Distance(p1, p2);

            if (_lastDist != 0)
            {
                var scaling = _lastDist - _dist;
                ScaleModel(scaling);
            }
            _lastDist = _dist;
        }
    }

    private void RotateModel()
    {
        var curRot = transform.rotation;
        var futRot = Quaternion.Euler(0, _xRot, 0);
        transform.rotation = Quaternion.Lerp(curRot, futRot, Time.deltaTime * 10);
    }

    private void ScaleModel(float scaling)
    {
        scaling /= -1000;
        var scale = transform.localScale;
        if (scale.x + scaling < 0.01) return;
        transform.localScale = new Vector3(scale.x + scaling, scale.y + scaling, scale.z + scaling);
    }
}


