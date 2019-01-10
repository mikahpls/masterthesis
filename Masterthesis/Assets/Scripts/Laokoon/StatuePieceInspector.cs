using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePieceInspector : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void ClonePiece(GameObject obj)
    {
        var go = GameObject.Instantiate(obj, transform);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<StatuePiece>().enabled = false;
        Destroy(go.GetComponent<StatuePiece>());
        go.AddComponent<PieceRotator>();
    }
}
