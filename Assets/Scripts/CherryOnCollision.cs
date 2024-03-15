using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CherryOnCollision : MonoBehaviour
{
    [SerializeField] private int POINTS = 100; 
    private ScoreManager scoreManager;
    void Start()
        {
            scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager == null)
            {
                Debug.LogError("ScoreManager not found in scene! Ensure it exists.");
            }
        }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Entering Trigger");
        if (trigger.CompareTag("Player"))
        {
            print("Ouch");
            scoreManager.AddScore(POINTS);
            Destroy(gameObject);
            print("Player Collide");
        }
        print("exit trigger");
    }
}