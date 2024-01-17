using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // The target to follow (your character)
    public float distance = 5.0f; // The distance from the target
    public float height = 2.0f; // The height above the target
    public float rotationSpeed = 3.0f; // The maximum rotation speed when rotating horizontally
    public float acceleration = 5.0f; // The acceleration for camera rotation
    public float deceleration = 7.0f; // The deceleration for camera rotation

    private float currentRotationSpeed = 0.0f;
    private float inputX = 0.0f;

    public float orbitSpeed = 3f;
    public bool isOrbiting = false;

    private void Update()
    {
        if (!target)
            return;

        // Capture horizontal mouse input for camera rotation
        inputX = Input.GetAxis("Mouse X");

        if(!isOrbiting)
        {
            // Apply acceleration and deceleration
            if (Mathf.Abs(inputX) > 0.01f)
            {
                currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, inputX * rotationSpeed, Time.deltaTime * acceleration);
            }
            else
            {
                currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, Time.deltaTime * deceleration);
            }
        }
        if (isOrbiting)
        {
            target = null;
            target = GameObject.FindGameObjectWithTag("OrbitTarget").transform;
            AutoOrbit();
        }
    }

    private void LateUpdate()
    {
        if (!target)
            return;

        // Calculate the desired rotation angle based on the target's current rotation and mouse input
        float desiredRotationAngle = transform.eulerAngles.y + currentRotationSpeed * Time.deltaTime;

        // Calculate the current height
        float currentHeight = target.position.y + height;

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, desiredRotationAngle, 0);

        // Set the position of the camera using the target's position and the calculated height and distance
        Vector3 targetPosition = target.position - currentRotation * Vector3.forward * distance;
        targetPosition.y = currentHeight;

        // Apply the final position and rotation to the camera
        transform.position = targetPosition;
        transform.LookAt(target);
    }
    void AutoOrbit()
    {
        // Calculate the desired rotation based on time
        float rotationAmount = orbitSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0, rotationAmount, 0);

        // Apply the rotation to the camera position relative to the target
        transform.RotateAround(target.position, Vector3.up, rotationAmount);
        transform.LookAt(target.position);
    }
}
