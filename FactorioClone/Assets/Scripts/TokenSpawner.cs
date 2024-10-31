using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{

    // [SerializeField] GameObject tokenPrefab;
    // [SerializeField] float spawnTime = 1f;

    // public float timer = 0;

    // void SpawnToken() {
    //     float randomX = Random.Range(-8f, 8f);
    //     GameObject newToken = Instantiate(tokenPrefab, new Vector3(randomX, 5f, 0), Quaternion.identity);
    //     Destroy(newToken, 5);
    // }

    public void Update() {
        // timer += Time.deltaTime;
        // if (timer >= spawnTime) {
            // SpawnToken();
            // timer = 0;
        // }
    }
}
