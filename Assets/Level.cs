using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private Coin[] coins;
    [SerializeField] private string nextLevel;
    [SerializeField] private Player player;
    private int collectedCoins = 0;
    

    private void Awake()
    {
        foreach (var c in coins)
        {
            c.OnCoinCollected += CheckForLevelEnd;
        }
    }

    private void Update()
    {
        if(player.transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void CheckForLevelEnd()
    {
        collectedCoins++;
        if (coins.Length == collectedCoins)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
