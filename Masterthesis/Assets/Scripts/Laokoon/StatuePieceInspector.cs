﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StatuePieceInspector : MonoBehaviour
{
    public GameObject SPIButton, SPIInfo;
    private GameObject _currentSelectedStatuePiece, _clonePiece;
    public ModelTargetBehaviour ModelTarget;
    public UITransformOnOff laokoonOnOff;

    public void ClonePiece(GameObject obj)
    {
        if (_currentSelectedStatuePiece == null)
        {
            _currentSelectedStatuePiece = obj;
            SPIButton.SetActive(true);

            _clonePiece = GameObject.Instantiate(obj, transform);
            _clonePiece.transform.localPosition = Vector3.zero;
            _clonePiece.GetComponent<StatuePiece>().enabled = false;
            Destroy(_clonePiece.GetComponent<StatuePiece>());
            _clonePiece.AddComponent<PieceRotator>();

            SPIInfo.SetActive(true);
            var uiloader = SPIInfo.GetComponent<UIInformationLoader>();
            var data = uiloader.GetDataAsStringArray(obj.name);
            uiloader.Name.text = data[0];
            uiloader.Information.text = data[1];
        }
    }

    public void DeselectStatuePiece()
    {
        _currentSelectedStatuePiece = null;
        laokoonOnOff.TransformOnOff();
        Destroy(_clonePiece);
        SPIButton.SetActive(false);
        SPIInfo.SetActive(false);
    }
}
