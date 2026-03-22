using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject coinPrefab;
    public Transform[] spawnPoints;
    public int poolSize = 10;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Create pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(coinPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        SpawnCoins();

        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetTotalCoins(spawnPoints.Length);
        }
    }

    void SpawnCoins()
    {
        foreach (Transform spawn in spawnPoints)
        {
            GameObject coin = Get();
            coin.transform.position = spawn.position;
        }
    }

    public GameObject Get()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(coinPrefab);
        pool.Add(newObj);
        return newObj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}