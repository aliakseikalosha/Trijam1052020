using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Action OnCoinCollected;
    [SerializeField] private SpriteRenderer sprite;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        sprite.transform.LookAt(mainCamera.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnCoinCollected?.Invoke();
        }
    }
}
