using System.Collections.Generic;
using UnityEngine;


public class AssaultRifle : Weapon
{
    //public override float BestFireDistance { get { return 10; } }

    public float bulletSpread = 5f; // 子弹散布范围
    public BulletPool.BulletType bulletType = BulletPool.BulletType.AssaultRifleBullet;
    public override void Shoot(Vector2 direction)
    {
        if (currentAmmo <= 0) return;
        currentAmmo--;

        float angleOffset = Random.Range(-bulletSpread / 2, bulletSpread / 2);
        Quaternion bulletRotation = Quaternion.Euler(0, 0, angleOffset) * Quaternion.LookRotation(Vector3.forward, direction);

        Bullet bullet = BulletPool.Instance.Get(bulletType);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = bulletRotation;

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bullet.transform.up * shootForce;
    }
}
