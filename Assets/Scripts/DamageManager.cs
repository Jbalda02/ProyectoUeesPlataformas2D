using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private ScoreManager _sm;
    private GameObject Player;
    [SerializeField] private Transform spawn;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _sm = FindObjectOfType<ScoreManager>();
        if (_sm == null)
        {
            Debug.LogError("ScoreManager not found in scene! Ensure it exists.");
        }
    }
    public void DoDamage()
    {
        Player.transform.position = spawn.position;
        _sm.ResetScore();
        
    }

    public void KillEnemy()
    {
        _sm.AddScore(100);
    }
}
