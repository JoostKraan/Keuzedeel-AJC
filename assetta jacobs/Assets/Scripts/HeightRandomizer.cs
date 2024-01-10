using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightRandomizer : MonoBehaviour
{
    public float minY = 0f; // Minimum Y-axis scale
    public float maxY = 2f; // Maximum Y-axis scale

    // Start is called before the first frame update
    void Start()
    {
        // Get the current scale of the GameObject
        Vector3 currentScale = transform.localScale;

        // Set a random Y-axis scale within the specified range
        float randomY = Random.Range(minY, maxY);

        // Update the Y-axis scale of the object
        currentScale.y = randomY;

        // Apply the new scale to the GameObject
        transform.localScale = currentScale;
    }
}
