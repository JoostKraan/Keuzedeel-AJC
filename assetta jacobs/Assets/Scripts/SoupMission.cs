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

    [SerializeField] GameObject _Soep;
    [SerializeField] GameObject soepInPan;
    public bool isinRangeOfSoupDelivery = false;
    public bool soupIsGiven = false;
    public bool isHoldingSoup = false;
    public bool isInRange = false;
    void Start()
    {
        holdingItems = GameObject.FindObjectOfType<HoldingItems>();
        missionManager = GameObject.FindObjectOfType<MissionManager>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        cameraScript= GameObject.FindObjectOfType<CameraScript>();
    }

    void Update()
    {
        if (isHoldingSoup)
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
        if (isHoldingSoup)
        {
            if (isinRangeOfSoupDelivery)
            {                
                if (Input.GetKey(KeyCode.E))
                {
                    isHoldingSoup = false;
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
        if (other.gameObject.CompareTag("InRangeOfSoup"))
        {
            isInRange = true;
            if (!isHoldingSoup)
            {
                arrow.SetActive(false);
                helpText.SetActive(true);
            }
        }
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
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InRangeOfSoup"))
        {
            isInRange = false;
            if (!isHoldingSoup)
            {
                arrow.SetActive(true);
                helpText.SetActive(false);
            }
            if (isHoldingSoup)
            {
                arrow.SetActive(false);
                helpText.SetActive(false);
            }
        }
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
    }
}
