using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolPrefabs : MonoBehaviour
{
    [SerializeField] private List<Pool> pools = new List<Pool>();
    [SerializeField] private Vector3 positionPrefab;
    [SerializeField] private bool nestUnderParent;

    public Action<GameObject> blocks;
    private List<GameObject> poolerBlocks;

    private void Start()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        poolerBlocks = new List<GameObject>();
        GameObject tempBlock;
        for (int i = 0; i < pools.Count; i++)
        {
			tempBlock = Instantiate(pools[Mathf.Abs(Random.Range(0, pools.Count))].poolBlocks, positionPrefab * i, Quaternion.identity);
            if(nestUnderParent) tempBlock.transform.SetParent(transform);
            poolerBlocks.Add(tempBlock);
            tempBlock.SetActive(false);
        }
    }

    private GameObject GetBlocks()
    {
        for (int i = 0; i < poolerBlocks.Count; i++)
        {
            if (!poolerBlocks[i].activeInHierarchy)
            {
                return poolerBlocks[i];
            }
        }
        return null;
    }
    
    // Unity Button
    public void ButtonnClick()
    {
		blocks?.Invoke(GetBlocks());
    }

    public void ResetClick()
    {
		for (int i = 0; i < poolerBlocks.Count; i++)
		{
			DestroyImmediate(poolerBlocks[i], true);
		}
		poolerBlocks.Clear();
        SpawnBlocks();
    }

}


[Serializable]
public struct Pool
{
    public GameObject poolBlocks;
}