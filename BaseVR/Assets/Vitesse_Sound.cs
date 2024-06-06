using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitesse_Sound : MonoBehaviour
{
    private CharacterController characterController;
    
    public AudioClip soundEffect;
    private AudioSource audioSource;
    private CameraShake cameraShake;
    bool canFall = true;
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

        if (speedY < -3f && speedY > -4f)
        {
            canFall = false;
            Debug.Log("Début de la chute");
            FallStart = true;
            audioSource.Play();
            Debug.Log("Play du son de chute");
        }

        if (FallStart)
        {
            if (speedY < -53)
            {
                Debug.Log("Fin de la chute");
                FallStart = false;
                canFall = true;
                FallEnd = true;
                cameraShake.shakeDuration = 0;
                audioSource.Stop();
            }
            else if (speedY < -4f)
            {
                Debug.Log("Chute en cours");
                float newShakeAmount = Mathf.Abs(speedY) * cameraShake.increaseFactor * 0.1f;
                cameraShake.UpdateShakeAmount(newShakeAmount);
                cameraShake.shakecamera();
                audioSource.volume += 0.005f;
            }
        }
    }
}
