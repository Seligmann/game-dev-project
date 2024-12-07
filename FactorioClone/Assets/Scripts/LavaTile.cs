using UnityEngine;

public class LavaTile : MonoBehaviour
{
    private int damagePerSecond = 10;

    public void SetDamage(int damage)
    {
        damagePerSecond = damage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Slime>().DecreaseHpBy(damagePerSecond);
        }
    }
}
