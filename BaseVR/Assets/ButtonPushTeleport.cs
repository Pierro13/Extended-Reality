using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonPushTeleport : MonoBehaviour
{
    public GameObject playerRig;
    public Vector3 teleportLocation;
    public static int compteur = 0;

    [SerializeField] private GameObject Chx1_1;
    [SerializeField] private GameObject Chx2_1;
    [SerializeField] private GameObject Sol_de_Stop;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TeleportPlayer());
    }


    public void TeleportPlayer()
    {

            if (Chx1_1 != null)
            {
                Chx1_1.SetActive(false);
            } 
            else 
            {
                Debug.Log("Chx1 is null");
            }

            if (Chx2_1 != null)
            {
                Chx2_1.SetActive(false);
            } 
            else 
            {
                Debug.Log("Chx2 is null");
            }

            if (Sol_de_Stop != null)
            {
                Sol_de_Stop.SetActive(true);
            } 
            else 
            {
                Debug.Log("Sol_de_Stop is null");
            }


        GameObject bravo = GameObject.FindGameObjectWithTag("Bravo");
        if (bravo != null)
        {
            bravo.SetActive(false);
        }

        GameObject plane = GameObject.FindGameObjectWithTag("plan_de_tempo");
        if (plane != null)
        {
            plane.SetActive(true);
        }

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
