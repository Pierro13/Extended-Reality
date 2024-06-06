using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mort : MonoBehaviour
{
    public AudioClip soundEffect1;
    private AudioSource audioSource1;

    public AudioClip soundEffect2;
    private AudioSource audioSource2;

    public AudioClip BackgroundMusic;
    private AudioSource audioSource3;


    private CameraShake cameraShake;

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();

        cameraShake = GetComponent<CameraShake>(); // Assurez-vous que le composant CameraShake est attaché au même GameObject

        audioSource1.clip = soundEffect1;
        audioSource2.clip = soundEffect2;
        audioSource3.clip = BackgroundMusic;

        audioSource3.loop = true;
        audioSource3.volume = 0.05f;
        PlayBackgroundMusic();
    }

    void Update()
    {
        //Vector3(1.24353027,-2.10899925,0.49206543)
        //Vector3(-171.852432,20.606987,1146.52563)
    }

    public void PlayBackgroundMusic()
    {
        audioSource3.Play();
    }


    bool isMort = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundCollision"))
        {
            isMort = true;
        }

        // if(other.gameObject.layer == LayerMask.NameToLayer("GroundOfDeath"))
        // {
        //     isMort = true;
        // }

        if(isMort)
        {
            if (cameraShake != null)
            {
                cameraShake.shakecamera();
            }

            if (audioSource1 != null && !audioSource1.isPlaying)
            {
                audioSource1.Play();
            }

            if (audioSource2 != null && !audioSource2.isPlaying)
            {
                audioSource2.Play();
            }

            Debug.Log("Mort via le Tag");
            
            transform.position = new Vector3(-171.602997f,21.1350002f,1145.90796f); 
            transform.rotation = Quaternion.Euler(0f,226.446594f,0f);
            audioSource3.Stop();

        }
    }

}
