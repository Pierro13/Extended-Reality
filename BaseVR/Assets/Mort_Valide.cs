using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mort_Valide : MonoBehaviour
{
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Validate_Mort());
    }


    public void Validate_Mort()
    {
        GameObject plane = GameObject.FindGameObjectWithTag("plan_de_tempo");
        if (plane != null)
        {
            plane.SetActive(false);
        }
    }
}
