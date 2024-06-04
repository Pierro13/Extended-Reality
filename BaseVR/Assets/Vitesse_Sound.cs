using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitesse_Sound : MonoBehaviour
{
    private CharacterController characterController;
    bool isFalling = false;
    bool FallStart = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float speedY = characterController.velocity.y;
        // Debug.Log("Speed along Y axis: " + speedY);

        if(speedY < -1f && !isFalling)
        {
            isFalling = true;
            Debug.Log("Début de la chute");
            FallStart = true;
        }

        if(FallStart && speedY < -53){
            Debug.Log("Fin de la chute");
            FallStart = false;
        }

        if(FallStart && speedY == 0){
            isFalling = false;
        }

    }
}
