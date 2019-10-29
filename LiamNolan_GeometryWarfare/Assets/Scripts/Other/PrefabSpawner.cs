using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    private int minimumCount = 3;
    [SerializeField]
    private int maximumCount = 5;
    [SerializeField]
    private GameObject prefab = null;

    public int MinimumCount
    {
        get { return this.minimumCount; }
        set { this.minimumCount = value; }
    }

    public int MaxiumCount
    {
        get { return this.maximumCount; }
        set { this.maximumCount = value; }
    }

    public GameObject Prefab
    {
        get { return this.prefab; }
        set { this.prefab = value; }
    }
    
    public void Spawn()
    {
        // Randomly pick the count of prefabs to spawn
        int count = Random.Range(this.MinimumCount, this.MaxiumCount);
        // Spawn them
        for (int i = 0; i < count; ++i)
        {
            Instantiate(this.prefab, this.transform.position, Quaternion.identity);
        }
    }
}
