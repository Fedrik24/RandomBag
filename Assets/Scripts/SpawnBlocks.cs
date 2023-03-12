using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] private PoolPrefabs poolPrefabs;


    private void Awake()
    {
        poolPrefabs.blocks += OnSpawnBlocks;
    }

    private void OnSpawnBlocks(GameObject go)
    {
        if(go == null) return;
        go.transform.Translate(transform.position);
        go.SetActive(true);
    }
}
