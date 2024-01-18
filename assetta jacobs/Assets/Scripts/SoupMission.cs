using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupMission : MonoBehaviour
{
    HoldingItems holdingItems;
    MissionManager missionManager;
    PlayerController playerController;
    CameraScript cameraScript;
    [SerializeField] GameObject placedSoup;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject deliveryArrow;
    [SerializeField] GameObject helpText;
    [SerializeField] GameObject helpDeliverSoupText;
    [SerializeField] GameObject thankYouText;
    public bool isinRangeOfSoupDelivery = false;
    public bool soupIsGiven = false;
    void Start()
    {
        holdingItems = GameObject.FindObjectOfType<HoldingItems>();
        missionManager = GameObject.FindObjectOfType<MissionManager>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        cameraScript= GameObject.FindObjectOfType<CameraScript>();
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
                    helpDeliverSoupText.SetActive(false);
                    soupIsGiven = true;
                }
            }
        }
        if(soupIsGiven)
        {
            thankYouText.SetActive(true);
            missionManager.CompleteMission();
            playerController.isAloudToMove = false;
            cameraScript.isOrbiting = true;

        }
        if(helpText != null)
        {
            if (helpText.active == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    helpText.SetActive(false);
                }
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("inRangeOfSoupDelivery"))
        {
            isinRangeOfSoupDelivery = true;
            if(!soupIsGiven)
            {
                deliveryArrow.SetActive(false);
                helpDeliverSoupText.SetActive(true);
            }
            if (soupIsGiven)
            {
                deliveryArrow.SetActive(false);
                helpDeliverSoupText.SetActive(false);
            }
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
            if (!soupIsGiven)
            {
                deliveryArrow.SetActive(true);
                helpDeliverSoupText.SetActive(false);
            }
            if (soupIsGiven)
            {
                deliveryArrow.SetActive(false);
                helpDeliverSoupText.SetActive(false);
            }
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
