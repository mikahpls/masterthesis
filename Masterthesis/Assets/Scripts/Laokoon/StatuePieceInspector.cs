using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePieceInspector : MonoBehaviour
{
    public GameObject SPIButton;
    private GameObject _currentSelectedStatuePiece, _clonePiece;

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
        }
    }

    public void DeselectStatuePiece()
    {
        _currentSelectedStatuePiece = null;
        Destroy(_clonePiece);
        SPIButton.SetActive(false);
    }
}
