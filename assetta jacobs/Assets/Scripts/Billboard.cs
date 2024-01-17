using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {
        // Ensure the canvas always faces the main camera
        FaceCamera();
    }

    void FaceCamera()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Calculate the rotation needed to face the camera
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                mainCamera.transform.rotation * Vector3.up);
        }
        else
        {
            Debug.LogError("Main camera not found. Make sure there is an active camera in the scene.");
        }
    }
}
