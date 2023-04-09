using UnityEngine;

public class Sniper : Weapon
{
    public BulletPool.BulletType bulletType = BulletPool.BulletType.SniperBullet;

    public override void Shoot(Vector2 direction)
    {
        if (currentAmmo <= 0) return;
        currentAmmo--;

        Bullet bullet = BulletPool.Instance.Get(bulletType);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bullet.transform.up * shootForce;
    }
}