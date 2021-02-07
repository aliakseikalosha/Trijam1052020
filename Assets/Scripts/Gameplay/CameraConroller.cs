using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;

    private void Update()
    {
        if (Input.GetKeyDown(rotateLeft))
        {
            Rotate(45f);
        }
        if (Input.GetKeyDown(rotateRight))
        {
            Rotate(-45f);
        }
    }

    private void Rotate(float v)
    {
        mainCamera.transform.RotateAround(target.position, Vector3.up, v );
    }
}
