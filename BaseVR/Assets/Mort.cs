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
        audioSource3.volume = 0.5f;
        audioSource3.Play();
    }

    void Update()
    {
        //Vector3(1.24353027,-2.10899925,0.49206543)
        //Vector3(-171.852432,20.606987,1146.52563)
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
            // Debug.Log("Mort via le Layer");
            
            transform.position = new Vector3(-171.538559f,21.4302406f,1146.39136f); 
            transform.rotation = Quaternion.Euler(0f,216.767731f,0f);
            audioSource3.Stop();

            // StartCoroutine(LoadGameOverScene());
        }
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}
