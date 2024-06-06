using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    public float shakeDuration = 10f;
    public float shakeAmount = 0.7f;
    public float increaseFactor = 0.08f;
    public float decreaseFactor = 1.0f;

    public bool shaketrue = false;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shaketrue)
        {
            Debug.Log("Shake !");

            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 1f;
                camTransform.localPosition = originalPos;
                shaketrue = false;
            }
        }
    }

    public void shakecamera()
    {
        shaketrue = true;
    }

    public void UpdateShakeAmount(float newShakeAmount)
    {
        shakeAmount = newShakeAmount;
    }
}
