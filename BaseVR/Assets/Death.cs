using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class Death : MonoBehaviour
{
    public XROrigin xrOrigin;
    [SerializeField] DynamicMoveProvider moveProvider;

    void Start()
    {
        if (xrOrigin == null)
        {
            Debug.LogError("Y a pas de XROrigin");
        }

        if (moveProvider == null)
        {
            Debug.LogError("Y a pas de DynamicMoveProvider");
        }
    }

    void Update()
    {

        Debug.Log(moveProvider.moveSpeed);

        if (xrOrigin != null && moveProvider != null)
        {
            if (xrOrigin.transform.position.y < 25)
            {
                Debug.Log("Mort");
                moveProvider.moveSpeed = 0;
            }
        }
    }
}
