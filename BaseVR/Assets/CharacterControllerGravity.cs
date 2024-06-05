using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGravity : MonoBehaviour
{
    private CharacterController _characterController;
    private float _gravity = 9.8f; // Adjust the gravity value as needed

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Debug.Log("CharacterController Height: " + _characterController.height);
    }

    void FixedUpdate()
    {
        if (!_characterController.isGrounded)
        {
            // Apply gravity to the character controller
            _characterController.Move(Vector3.down * _gravity * Time.deltaTime);
        }
    }
}