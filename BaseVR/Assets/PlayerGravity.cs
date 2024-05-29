using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float gravity = -9.81f;
    private Vector3 velocity;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
