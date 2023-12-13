using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupMission : MonoBehaviour
{
    HoldingItems holdingItems;
    [SerializeField] GameObject placedSoup;
    public bool isinRangeOfSoupDelivery = false;
    void Start()
    {
        holdingItems = GameObject.FindObjectOfType<HoldingItems>();   
    }

    void Update()
    {
        if(holdingItems.isHoldingSoup)
        {
            if (isinRangeOfSoupDelivery)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    holdingItems.isHoldingSoup = false;
                    placedSoup.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("inRangeOfSoupDelivery"))
        {
            isinRangeOfSoupDelivery = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("inRangeOfSoupDelivery"))
        {
            isinRangeOfSoupDelivery = false;
        }
    }
}
