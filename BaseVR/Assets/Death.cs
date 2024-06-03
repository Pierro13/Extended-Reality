using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class Death : MonoBehaviour
{
    public XROrigin xrOrigin;

    void Start()
    {
        if (xrOrigin == null)
        {
            Debug.LogError("Y a pas de XROrigin");
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundCollision"))
        {
            Debug.Log("Mort via le TAG");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("GroundOfDeath"))
        {
            Debug.Log("Mort via le Layer");
        }
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
