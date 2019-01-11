
using System;
using UnityEngine;

public class PieceRotator : MonoBehaviour
{
    private float rotSpeed = 150;
    private float _dist, _lastDist;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right, rotY, Space.World);
    }

    //void OnMouseOver()
    //{
    //    //OnClick
    //    if (Input.GetMouseButtonDown(0))
    //    {
            
    //    }
    //}

    void Update()
    {
        if (Input.touchCount == 0)
        {
            _lastDist = _dist = 0;
        }

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

    private void ScaleModel(float scaling)
    {
        scaling /= -1000;
        var scale = transform.localScale;
        if (scale.x + scaling < 0.01) return;
        transform.localScale = new Vector3(scale.x + scaling, scale.y + scaling, scale.z + scaling);
    }
}


