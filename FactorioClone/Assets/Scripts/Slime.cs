using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float speed = 5;

    Rigidbody2D rb;

    public int points;
    public int coal = 0;
    public int iron = 0;
    public int machinesInInven = 0;
    [SerializeField] GameObject tokenSpawner;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        points = 0;
    }

    public void Move(Vector3 movement) {
        rb.velocity = movement * speed;
    }

    public void IncreaseCoal() {
        coal += 1;
    }

    public void IncreaseIron() {
        iron += 1;
    }

    // void OnTriggerEnter2D(Collider2D other) {
    //     if (other.CompareTag("Token")) {
    //         tokenSpawner.GetComponent<AudioSource>().Play();
    //         Destroy(other.gameObject);
    //         IncreasePoints();
    //     } else if (other.CompareTag("Asteroid")) {
    //         SceneManager.LoadScene("MainMenu");
    //         ResetPoints();
    //     }
    // }
}
