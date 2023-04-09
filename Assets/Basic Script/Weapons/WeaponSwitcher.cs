using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeaponIndex = 0;
    private List<Weapon> weapons;

    void Start()
    {
        weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
        ActivateCurrentWeapon();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        currentWeaponIndex++;
        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        ActivateCurrentWeapon();
    }

    void ActivateCurrentWeapon()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(i == currentWeaponIndex);
        }
    }
}
