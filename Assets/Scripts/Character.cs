using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // 死亡时的逻辑，比如播放动画、音效等
        Debug.Log(gameObject.name + " died.");
    }
}
