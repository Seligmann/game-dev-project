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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iron = 0;
            coal = 0;
            machinesInInven = 0;
            GameObject[] machines = GameObject.FindGameObjectsWithTag("Machine");

            foreach (GameObject machine in machines)
            {
                Destroy(machine);
            }
            GameObject[] coals = GameObject.FindGameObjectsWithTag("Coal");

            foreach (GameObject coalOre in coals)
            {
                Destroy(coalOre);
            }
            GameObject[] irons = GameObject.FindGameObjectsWithTag("Iron");

            foreach (GameObject ironOre in irons)
            {
                Destroy(ironOre);
            }
            SceneManager.LoadScene("MainMenu");
        }
    }
}
