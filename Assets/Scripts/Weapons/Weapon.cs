using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    public int maxAmmo = 30;
    public int currentAmmo;
    public float fireRate = 5f;
    public float reloadTime = 1f;
    public Transform firePoint;
    public Camera cam;
    public float shootForce;

    protected bool isReloading = false;
    protected float nextFireTime = 0f;

    public bool ownerPlayer = true;

    public bool isAutomatic = false;

    public bool isOwnedByPlayer = true;

    public Vector3 aiShootDir;
    public bool aiShoot = false;

    public float bestFireDistance;
    //public abstract float BestFireDistance { get; }

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    protected virtual void Update()
    {
        if (isReloading) return;

        if (currentAmmo <= 0)
        {
            Reload();
            return;
        }
        float timeSinceLastShot = 0f;

        timeSinceLastShot = Time.time - nextFireTime;

        if (((ownerPlayer && Input.GetMouseButton(0)) || (!ownerPlayer && aiShoot)) && timeSinceLastShot >= 1f / fireRate)
        {
            nextFireTime = Time.time;
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 fireDirection = (mousePosition - (Vector2)firePoint.position).normalized;
            Shoot(fireDirection);
        }
        if (ownerPlayer)
        {
            UIUpdate.Instance.updateammo(currentAmmo);
            UIUpdate.Instance.updatereloading(reloadTime);
        }
    }
    public void Reload()
    {
        StartCoroutine(ReloadIE());
    }
    private IEnumerator ReloadIE()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public abstract void Shoot(Vector2 direction);

    public void AiShootCommand(bool shoot)
    {
        if (ownerPlayer)
        {
            return;
        }

        aiShoot = shoot;
    }
}
