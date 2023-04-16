using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [System.Serializable]
    public enum BulletType
    {
        AssaultRifleBullet,
        ShotgunPellet,
        SniperBullet
    }

    [System.Serializable]
    public class BulletPrefab
    {
        public BulletType bulletType;
        public Bullet prefab;
    }

    [SerializeField]
    private List<BulletPrefab> bulletPrefabs;
    [SerializeField]
    private int initialPoolSize = 10;

    private Dictionary<BulletType, Queue<Bullet>> bulletPools = new Dictionary<BulletType, Queue<Bullet>>();

    private void Awake()
    {
        Instance = this;

        foreach (var bulletPrefab in bulletPrefabs)
        {
            Queue<Bullet> bulletPool = new Queue<Bullet>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                Bullet newBullet = Instantiate(bulletPrefab.prefab);
                newBullet.gameObject.SetActive(false);
                bulletPool.Enqueue(newBullet);
            }
            bulletPools.Add(bulletPrefab.bulletType, bulletPool);
        }
    }

    public Bullet Get(BulletType bulletType)
    {
        Queue<Bullet> bulletPool = bulletPools[bulletType];

        if (bulletPool.Count == 0)
        {
            Bullet bulletPrefab = bulletPrefabs.Find(bp => bp.bulletType == bulletType).prefab;
            Bullet newBullet = Instantiate(bulletPrefab);
            bulletPool.Enqueue(newBullet);
        }

        Bullet bullet = bulletPool.Dequeue();
        bullet.spawn();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnToPool(Bullet bullet, BulletType bulletType)
    {
        bullet.gameObject.SetActive(false);
        bullet.Despawn();
        bulletPools[bulletType].Enqueue(bullet);
    }
}
