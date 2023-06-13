using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        // Disable all cameras except the first one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check for input to switch cameras
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Disable the current camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Increment the camera index
            currentCameraIndex++;

            // Wrap the camera index if it exceeds the number of cameras
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }

            // Enable the new camera
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}

