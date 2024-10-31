using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] float spawnTime = 1f;

    public float timer = 0;

    void SpawnAsteroid() {
        float randomX = Random.Range(-8f, 8f);
        GameObject newAsteroid = Instantiate(asteroidPrefab, new Vector3(randomX, 5f, 0), Quaternion.identity);
        Destroy(newAsteroid, 5);
    }

    public void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            // SpawnAsteroid();
            timer = 0;
        }
    }

}
