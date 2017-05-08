using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gvrControllerPointer;
    public GameObject head;
    public GameObject otherPlayersController;
    public GameObject playerCamera;

    public bool isControllable;

	// Use this for initialization
	void Start ()
    {
        if (isControllable)
        {
            TeleportEvent teleportEvent = GameObject.Find("TeleportController").GetComponent<ThomasTeleportController>().teleportEvent;
            teleportEvent.AddListener(HandleTeleportEvent);
            playerCamera.SetActive(true);
            gvrControllerPointer.SetActive(true);
            head.SetActive(false);
            otherPlayersController.SetActive(false);
        }
        else
        {
            playerCamera.SetActive(false);
            gvrControllerPointer.SetActive(false);
        }
	}

    private void HandleTeleportEvent(Vector3 worldPos)
    {
        gameObject.transform.position = new Vector3(worldPos.x, gameObject.transform.position.y, worldPos.z);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
