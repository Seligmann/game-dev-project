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
    public int hp = 100;
    [SerializeField] GameObject tokenSpawner;

    private Coroutine lavaDamageCoroutine;

    public void IncreaseHp()
    {
        hp += 20;
        if (hp > 100)
        {
            hp = 100;
        }
    }

    public void DecreaseHp()
    {
        hp -= 5;
        if (hp <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        points = 0;
    }

    public void Move(Vector3 movement)
    {
        rb.velocity = movement * speed;
    }

    public void IncreaseCoal()
    {
        coal += 1;
    }

    public void IncreaseIron()
    {
        iron += 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetGame();
        }
    }

    private void ResetGame()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heal"))
        {
            IncreaseHp();
            Destroy(collision.gameObject);
            Debug.Log("Healed! Current HP: " + hp);
        }
        else if (collision.CompareTag("Lava"))
        {
            if (lavaDamageCoroutine == null)
            {
                lavaDamageCoroutine = StartCoroutine(ApplyLavaDamage());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            if (lavaDamageCoroutine != null)
            {
                StopCoroutine(lavaDamageCoroutine);
                lavaDamageCoroutine = null;
            }
        }
    }

    private IEnumerator ApplyLavaDamage()
    {
        while (true)
        {
            DecreaseHpBy(10);
            Debug.Log("Lava damage! Current HP: " + hp);
            yield return new WaitForSeconds(1f);
        }
    }

    public void DecreaseHpBy(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void IncreaseHpBy(int amount)
    {
        hp += amount;
        if (hp > 100)
        {
            hp = 100;
        }
    }
}
