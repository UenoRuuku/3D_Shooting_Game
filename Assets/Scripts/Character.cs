using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float currentHealth;
    private bool FireOrNot = true;

    public bool isPlayer = true;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (!FireOrNot)
        {
            if (currentHealth < maxHealth)
                currentHealth++;
            else
                currentHealth = maxHealth;

            //Reload
        }
        if(isPlayer){
            UIUpdate.Instance.updatehealth(currentHealth);
        }
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

    public void ChangeToReload()
    {
        FireOrNot = false;
    }

    public void ChangeToFire()
    {
        FireOrNot = true;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
