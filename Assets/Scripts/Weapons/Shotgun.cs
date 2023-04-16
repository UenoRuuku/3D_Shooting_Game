using UnityEngine;
public class Shotgun : Weapon
{
    //public override float BestFireDistance { get { return 0; } }

    public int pelletsPerShot = 5;
    public float spreadAngle = 45f;
    public BulletPool.BulletType bulletType = BulletPool.BulletType.ShotgunPellet;

    public override void Shoot(Vector2 direction)
    {
        if (currentAmmo <= 0) return;
        currentAmmo--;

        for (int i = 0; i < pelletsPerShot; i++)
        {
            float angleOffset = Random.Range(-spreadAngle / 2, spreadAngle / 2);
            Quaternion pelletRotation = Quaternion.Euler(0, 0, angleOffset) * Quaternion.LookRotation(Vector3.forward, direction);

            Bullet pellet = BulletPool.Instance.Get(bulletType);
            pellet.transform.position = firePoint.position;
            pellet.transform.rotation = pelletRotation;

            Rigidbody2D pelletRb = pellet.GetComponent<Rigidbody2D>();
            pelletRb.velocity = pellet.transform.up * shootForce;
        }
    }
}
