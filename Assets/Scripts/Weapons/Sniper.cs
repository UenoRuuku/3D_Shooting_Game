using UnityEngine;

public class Sniper : Weapon
{
    //public override float BestFireDistance { get { return 30; } }

    public BulletPool.BulletType bulletType = BulletPool.BulletType.SniperBullet;

    public override void Shoot(Vector2 direction)
    {
        if (currentAmmo <= 0) return;
        currentAmmo--;

        Bullet bullet = BulletPool.Instance.Get(bulletType);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (isOwnedByPlayer)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            float rayDistance;

            Vector3 point = Vector3.zero;
            if (groundPlane.Raycast(ray, out rayDistance))
            {
                point = ray.GetPoint(rayDistance);

            }
            Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);

            bulletRb.velocity = (heightCorrectedPoint - firePoint.position) * shootForce;
        }
        else
        {

            bulletRb.velocity = aiShootDir * shootForce;
        }
    }
}