using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushTeleport : MonoBehaviour
{
    public GameObject playerRig;
    public Vector3 teleportLocation;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TeleportPlayer());
    }

    public void TeleportPlayer()
    {
        if (playerRig != null)
        {
            playerRig.transform.position = teleportLocation;
        }
        else
        {
            Debug.LogError("Player Rig is not assigned.");
        }
    }
}
