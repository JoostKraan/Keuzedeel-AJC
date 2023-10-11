using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.HighDefinition;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform player_Obj;
    public Rigidbody rb;

    public float rotationSpeed;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            player_Obj.forward = Vector3.Slerp(player_Obj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

    }

}
