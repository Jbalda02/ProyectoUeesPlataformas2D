using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_GENERATION_DISTANCE = 10f;
    [SerializeField] private Transform StartLevel;
    [SerializeField] private List<Transform> levelPartsList;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject grid;
    private Vector3 lastEndPosition;
    
    
    private void Awake()
    {
        player = GameObject.FindWithTag(tag: "Player");
        lastEndPosition = StartLevel.Find(n: "endPosition").position;
        grid = GameObject.FindWithTag(tag: "Grid");
    }

    void Update(){
        
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_GENERATION_DISTANCE)
        {
            SpawnLevelPart();
                    

        }
        
    }

    private void SpawnLevelPart()
    {
        Transform selectRandomType = levelPartsList[Random.Range(0,levelPartsList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(selectRandomType,lastEndPosition);
        lastLevelPartTransform.transform.parent = grid.transform;
        lastEndPosition = lastLevelPartTransform.Find("endPosition").position;
        
    }

    private Transform SpawnLevelPart(Transform levelPart,Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart,spawnPosition,Quaternion.identity);
        return levelPartTransform;
    }
}
