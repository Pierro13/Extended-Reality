using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGravity : MonoBehaviour
{
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (!_characterController.isGrounded)
        {
            _characterController.SimpleMove(new Vector3());
        }
    }
}