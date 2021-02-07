using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float speed = 10f;
    private Camera mainCamera;

    private bool IsGrounded
    {
        get
        {
            //todo add more Raycast
            if (Physics.Raycast(body.transform.position, Vector3.down, 1.1f, groundLayer))
            {
                return true;
            }
            return false;
        }
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        sprite.transform.LookAt(mainCamera.transform);
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce);
        }
        var dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.x -= 1;
        }
        dir = mainCamera.transform.rotation * dir;
        var newVelocity = dir * speed;
        newVelocity.y = body.velocity.y;
        body.velocity = newVelocity;
    }   
}
