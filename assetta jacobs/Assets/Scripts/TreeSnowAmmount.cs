using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSnowAmount : MonoBehaviour
{
    public float minSnowAmount = 0.0f;
    public float maxSnowAmount = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Set a random snow amount at the start
        SetRandomSnowAmount();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here if needed
    }

    // Function to set a random snow amount to the object's material
    void SetRandomSnowAmount()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Material material = renderer.material;

            if (material != null)
            {
                float randomSnowAmount = Random.Range(minSnowAmount, maxSnowAmount);
                material.SetFloat("_SnowAmount", randomSnowAmount);
            }
            else
            {
                Debug.LogError("Material is not assigned to the object.");
            }
        }
        else
        {
            Debug.LogError("Renderer component is not found on the object.");
        }
    }
}
