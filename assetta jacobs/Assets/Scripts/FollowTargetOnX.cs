using UnityEngine;

public class FollowTargetOnX : MonoBehaviour
{
    public Transform target; // The target to follow on the X-axis

    private void Update()
    {
        if (target != null)
        {
            // Get the current position of the object
            Vector3 currentPosition = transform.position;

            // Update the object's position to match the X-coordinate of the target
            currentPosition.x = target.position.x;

            // Assign the updated position back to the object
            transform.position = currentPosition;
        }
    }
}
