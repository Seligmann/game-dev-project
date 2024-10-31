using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject coalPrefab;
    public GameObject ironPrefab;

    [Header("Spawn Settings")]
    public int numCoalToSpawn = 5;
    public int numIronToSpawn = 5;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax = new Vector2();

    void Start()
    {
        PlaceRandomly(coalPrefab, numCoalToSpawn);
        PlaceRandomly(ironPrefab, numIronToSpawn);
    }

    private void PlaceRandomly(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }
}
