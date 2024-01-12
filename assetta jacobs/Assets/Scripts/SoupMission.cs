using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupMission : MonoBehaviour
{
    HoldingItems holdingItems;
    [SerializeField] GameObject placedSoup;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject deliveryArrow;
    [SerializeField] GameObject helpText;
    [SerializeField] GameObject helpDeliverSoupText;
    public bool isinRangeOfSoupDelivery = false;
    private bool soupIsGiven = false;
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
                    soupIsGiven = true;
                }
            }
        }
        if(helpText.active == true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                helpText.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("inRangeOfSoupDelivery"))
        {
            isinRangeOfSoupDelivery = true;
            deliveryArrow.SetActive(false);
            helpDeliverSoupText.SetActive(true);
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            if(!holdingItems.isHoldingSoup)
            {
                arrow.SetActive(false);
                helpText.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("inRangeOfSoupDelivery"))
        {
            isinRangeOfSoupDelivery = false;
            deliveryArrow.SetActive(true);
            helpDeliverSoupText.SetActive(false);
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            if (!holdingItems.isHoldingSoup)
            {
                arrow.SetActive(true);
                helpText.SetActive(false);
            }            
            if (holdingItems.isHoldingSoup)
            {
                arrow.SetActive(false);
                helpText.SetActive(false);
            }
        }
    }
}
