using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mort : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundCollision"))
        {
            Debug.Log("Mort via le TAG");
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("GroundOfDeath"))
        {
            Debug.Log("Mort via le Layer");
        }
    }
}
