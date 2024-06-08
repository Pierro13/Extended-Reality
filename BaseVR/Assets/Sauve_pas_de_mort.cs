using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauve_pas_de_mort : MonoBehaviour
{
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => TeleportPlayer());
    }


    public void TeleportPlayer()
    {
        if (playerRig != null)
        {
            playerRig.transform.position = Vector3(-706.909973f,22.0599995f,797.619995f);
        }

        GameObject bravo = GameObject.FindGameObjectWithTag("Bravo");
        if (bravo != null)
        {
            bravo.SetActive(true);
        }
    }
}