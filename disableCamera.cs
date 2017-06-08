using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCamera : MonoBehaviour
{

    public Camera cam;

    public void disableCam()
    {
        cam.GetComponent<CameraFollow>().enabled = false;
    }
}