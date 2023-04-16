using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float maxLifetime = 3f;
    public float damage = 10f;
    protected float remainingLifetime;

    public BulletPool.BulletType bulletType;

    protected virtual void OnSpawned()
    {
        remainingLifetime = maxLifetime;
    }

    protected virtual void OnDespawned()
    {
        remainingLifetime = 0;
    }

    private void Update()
    {
        remainingLifetime -= Time.deltaTime;
        if (remainingLifetime <= 0)
        {
            BulletPool.Instance.ReturnToPool(this,bulletType);
        }
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Wall"))
        {
            BulletPool.Instance.ReturnToPool(this,bulletType);
        }
        else
        {
            Character enemy = hitInfo.GetComponent<Character>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            BulletPool.Instance.ReturnToPool(this,bulletType);
        }
    }

    public void Despawn()
    {
        OnDespawned();
    }

    public void spawn(){
        OnSpawned();
    }
}
