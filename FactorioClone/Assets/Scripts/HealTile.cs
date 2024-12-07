using UnityEngine;

public class HealTile : MonoBehaviour
{
    private int healAmount = 20;

    public void SetHealAmount(int amount)
    {
        healAmount = amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Slime>().IncreaseHpBy(healAmount);
            Destroy(gameObject);
        }
    }
}
