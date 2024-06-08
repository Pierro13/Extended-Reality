using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonPushTeleport : MonoBehaviour
{
    public GameObject playerRig;
    public Vector3 teleportLocation;
    public static int compteur = 0;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TeleportPlayer());
    }


    public void TeleportPlayer()
    {

        // GameObject bravo = GameObject.FindGameObjectWithTag("Bravo");
        // if (bravo != null)
        // {
        //     bravo.SetActive(false);
        // }

        if (playerRig != null)
        {

            Debug.Log("1. Compteur = " + compteur);

            if (compteur != 0)
            {
                Sons_et_Camera instance = FindObjectOfType<Sons_et_Camera>();
                if (instance != null)
                {
                    instance.PlayBackgroundMusic();
                }
                else
                {
                    Debug.LogError("Sons_et_Camera is null.");
                }
            }

            compteur++;
            Debug.Log("2. Compteur = " + compteur);

            playerRig.transform.position = teleportLocation;
        }
        else
        {
            Debug.LogError("Player Rig is not assigned.");
        }
    }
}
