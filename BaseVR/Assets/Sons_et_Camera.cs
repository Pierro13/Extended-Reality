using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons_et_Camera : MonoBehaviour
{
    public AudioClip CrashsoundEffect1;
    private AudioSource audioSource1;

    public AudioClip CrashsoundEffect2;
    private AudioSource audioSource2;

    public AudioClip VentSoundEffect;
    private AudioSource audioSource3;

    public AudioClip BackgroundMusic;
    private AudioSource audioSource4;

    private CharacterController characterController;
    private CameraShake cameraShake;
    public Transform camTransform;
    public float shakeDuration = 10f;   
    public float shakeAmount = 0.7f;
    public float increaseFactor = 0.25f;
    public float decreaseFactor = 0.5f;
    public bool shaketrue = false;
    Vector3 originalPos;

    private bool isMort = false;
    private bool isInChute = false;

    public Sons_et_Camera instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
        

        audioSource1.clip = CrashsoundEffect1;
        audioSource2.clip = CrashsoundEffect2;
        audioSource3.clip = VentSoundEffect;
        

        
        PlayBackgroundMusic();

        characterController = GetComponent<CharacterController>();
        cameraShake = GetComponent<CameraShake>();
    }

    public void PlayBackgroundMusic()
    {
        Debug.Log("PlayBackgroundMusic");
        audioSource4 = gameObject.AddComponent<AudioSource>();
        audioSource4.clip = BackgroundMusic;
        audioSource4.loop = true;
        audioSource4.Play();
    }

    void Update()
    {
        // float speedY = characterController.velocity.y;
        // shakeAmount = Mathf.Abs(speedY) * cameraShake.increaseFactor * 0.1f;
        
        // if (shaketrue)
        // {
        //     Debug.Log("Shake !");
        //     Debug.Log("shakeDuration : " + shakeDuration);
        //     Debug.Log("shakeAmount : " + shakeAmount);
        //     if (shakeDuration > 0)
        //     {
        //         Debug.Log("Shake !");
        //         camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount * 50f;
        //         shakeDuration -= Time.deltaTime * decreaseFactor;
        //     }
        //     else
        //     {
        //         shakeDuration = 1f;
        //         camTransform.localPosition = originalPos;
        //         shaketrue = false;
        //     }
        // }
    }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Début_Chute"))
        {
            isInChute = true;
        }

        if (isInChute)
        {
            Debug.Log("Début de la chute");
            isInChute = false;
            audioSource3.Play();
            shaketrue = true;
        }

        if (other.CompareTag("Temp_Chute"))
        {
            GameObject Btn1 = GameObject.FindGameObjectWithTag("");
            if (Btn1 != null)
            {
                Btn1.SetActive(true);
            }

            GameObject Btn2 = GameObject.FindGameObjectWithTag("");
            if (Btn2 != null)
            {
                Btn2.SetActive(true);
            }
        }

        if (other.CompareTag("GroundCollision"))
        {
            isMort = true;
        }

        if (isMort)
        {
            Debug.Log("MORT");
            transform.position = new Vector3(-170.800003f,20.2399998f,1146.56897f);
            transform.rotation = Quaternion.Euler(0, 103.89f, 0);
            isMort = false;
            shaketrue = false;
            audioSource3.Stop();
            audioSource4.Stop();
            audioSource1.Play();
            audioSource2.Play();
        }
    }
}