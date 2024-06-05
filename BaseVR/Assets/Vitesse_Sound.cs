using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitesse_Sound : MonoBehaviour
{
    private CharacterController characterController;
    
    public AudioClip soundEffect;
    private AudioSource audioSource;
    private CameraShake cameraShake;
    bool isFalling = false;
    bool FallStart = false;
    bool FallEnd = false;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraShake = GetComponent<CameraShake>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
        audioSource.volume = .02f;
    }

    void Update()
    {
        float speedY = characterController.velocity.y;

        if (speedY < -2f && !isFalling)
        {
            isFalling = true;
            Debug.Log("Début de la chute");
            FallStart = true;

            if (!FallEnd)
            {
                audioSource.Play();
            }
        }

        if (FallStart)
        {
            if (speedY < -53)
            {
                Debug.Log("Fin de la chute");
                FallStart = false;
                isFalling = false;
                FallEnd = true;
                cameraShake.shakeDuration = 0;
                audioSource.Stop();
            }
            else if (speedY < 0)
            {
                // Debug.Log("Chute en cours");
                float newShakeAmount = Mathf.Abs(speedY) * cameraShake.increaseFactor * 0.1f;
                cameraShake.UpdateShakeAmount(newShakeAmount);
                cameraShake.shakecamera();
                
                audioSource.volume += 0.005f;
            }
        }

        if (FallStart && speedY == 0)
        {
            isFalling = false;
        }
    }
}
