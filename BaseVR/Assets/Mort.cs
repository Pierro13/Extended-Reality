using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mort : MonoBehaviour
{
    public AudioClip soundEffect1;
    public AudioClip soundEffect2;
    private AudioSource audioSource1;
    private AudioSource audioSource2;

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        
        audioSource1.clip = soundEffect1;
        audioSource2.clip = soundEffect2;
    }

    void Update()
    {
        
    }

    bool isMort = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundCollision"))
        {
            isMort = true;
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("GroundOfDeath"))
        {
            isMort = true;
        }

        if(isMort)
        {
            if (audioSource1 != null && !audioSource1.isPlaying)
            {
                audioSource1.Play();
            }

            if (audioSource2 != null && !audioSource2.isPlaying)
            {
                audioSource2.Play();
            }

            Debug.Log("Mort via le Tag");
            Debug.Log("Mort via le Layer");

            StartCoroutine(LoadGameOverScene());
        }
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}
