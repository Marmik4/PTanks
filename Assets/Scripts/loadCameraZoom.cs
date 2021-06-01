using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadCameraZoom : MonoBehaviour
{
    public bool cameraLd = false;
    public void cameraLoaded()
    {
        cameraLd = true;
        Debug.Log("true");
    }
}
