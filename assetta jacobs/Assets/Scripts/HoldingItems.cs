using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingItems : MonoBehaviour
{
    [SerializeField] GameObject _Soep;
    [SerializeField] GameObject soepInPan;
    Camera _Camera;
    public RaycastHit hit;
    public float raycastRange = 10f;
    public bool isHoldingSoup = false;
    public bool isInRange = false;
    private void Start()
    {
        _Camera = Camera.main;
    }
    void Update()
    {
        if(isHoldingSoup)
        {
            _Soep.SetActive(true);
        }
        else
        {
            _Soep.SetActive(false);
        }
        if (isInRange)
        {
            if (Input.GetKey(KeyCode.E))
            {
                {
                    isHoldingSoup = true;
                    soepInPan.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("InRangeOfSoup"))
        {
            isInRange = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InRangeOfSoup"))
        {
            isInRange = false;
        }
    }
}
