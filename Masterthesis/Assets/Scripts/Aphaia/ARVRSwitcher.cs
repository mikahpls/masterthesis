using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARVRSwitcher : MonoBehaviour {

    public GameObject ARCamera;
    public GameObject VRCamera;

    public void SwitchCamera()
    {
        if (ARCamera.activeSelf)
        {
            ARCamera.SetActive(false);
            VRCamera.SetActive(true);
        }
        else
        {
            VRCamera.SetActive(false);
            ARCamera.SetActive(true);
        }
    }
}
