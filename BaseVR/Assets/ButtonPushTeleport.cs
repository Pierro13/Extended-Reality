using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonPushTeleport : MonoBehaviour
{
    public GameObject playerRig;
    public Vector3 teleportLocation;
    private Mort Mort;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TeleportPlayer());

        Mort = GetComponent<Mort>();
    }

    public void TeleportPlayer()
    {
        if (playerRig != null)
        {
            playerRig.transform.position = teleportLocation;
            Mort.PlayBackgroundMusic();
        }
        else
        {
            Debug.LogError("Player Rig is not assigned.");
        }
    }
}
