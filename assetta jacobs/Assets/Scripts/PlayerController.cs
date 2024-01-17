using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float moveSpeed = 5.0f; // Player movement speed
    public float rotationSpeed = 5.0f; // Player rotation speed
    public float gravity = 9.81f; // Gravitational acceleration
    public GameObject canvas;
    public GameObject meshToAnimate;
    public bool isAloudToMove = true;

    private CharacterController characterController;
    private float verticalVelocity = 0.0f;

    Animator animator;
    HoldingItems holdingItems;
    SoupMission soupMission;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        characterController = GetComponent<CharacterController>();

        animator = meshToAnimate.gameObject.GetComponent<Animator>();
        holdingItems = GetComponent<HoldingItems>();
        soupMission = GetComponent<SoupMission>();
    }

    private void Update()
    {
        // Get input for player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on camera orientation
        Vector3 moveDirection = cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput;
        moveDirection.y = 0; // Ensure no vertical movement

        //animation
        
        if(isAloudToMove)
        {
            if (holdingItems.isHoldingSoup)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("Idle", false);
                    animator.SetBool("Walking", false);
                    animator.SetBool("HoldingSoupIdle", false);
                    animator.SetBool("HoldingSoupWalking", true);
                }
                else
                {
                    animator.SetBool("Idle", false);
                    animator.SetBool("Walking", false);
                    animator.SetBool("HoldingSoupWalking", false);
                    animator.SetBool("HoldingSoupIdle", true);
                }
            }
            else if (holdingItems.isHoldingSoup == false)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("Idle", false);
                    animator.SetBool("Walking", true);
                }
                else
                {
                    animator.SetBool("Walking", false);
                    animator.SetBool("Idle", true);
                }
            }

            // Normalize to maintain consistent movement speed in all directions
            if (moveDirection.magnitude > 1.0f)
            {
                moveDirection.Normalize();
            }

            // Apply movement to the player using CharacterController
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            // Apply gravity
            if (characterController.isGrounded)
            {
                verticalVelocity = 0;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            // Apply vertical velocity to the player
            Vector3 verticalMove = Vector3.up * verticalVelocity * Time.deltaTime;
            characterController.Move(verticalMove);

            // Rotate the player in the direction of movement
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else 
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
        }
    }
}
