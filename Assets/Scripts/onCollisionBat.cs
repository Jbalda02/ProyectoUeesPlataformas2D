using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionBat : MonoBehaviour
{
    private  DamageManager _dm;
    void Start()
    {
        _dm = FindObjectOfType<DamageManager>();
        if (_dm == null)
        {
            Debug.LogError("ScoreManager not found in scene! Ensure it exists.");
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            _dm.DoDamage();
            Destroy(gameObject);
            
        }

        if (trigger.CompareTag("Bullet"))
        {
            _dm.KillEnemy();
            Destroy(gameObject);
        }

    }
}
