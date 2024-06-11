using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sauve_pas_de_mort : MonoBehaviour
{
    public GameObject playerRig;
    public GameObject bravo;
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TeleportPlayer());
    }


    public void TeleportPlayer()
    {
        if (playerRig != null)
        {
            playerRig.transform.position = new Vector3(-706.909973f, 22.0599995f, 797.619995f);
        }

        if (bravo != null)
        {
            bravo.SetActive(true);
        }
        else 
        {
            Debug.Log("Bravo is null");
        }
    }
}