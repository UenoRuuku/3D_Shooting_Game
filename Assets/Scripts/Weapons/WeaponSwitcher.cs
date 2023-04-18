using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeaponIndex = 0;
    public List<Weapon> weapons;

    public bool isPlayer = true;

    void Start()
    {
        //weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
        ActivateCurrentWeapon();
    }

    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    public void SwitchWeapon()
    {
        currentWeaponIndex++;
        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        ActivateCurrentWeapon();
    }

    public Weapon GetCurrentWeapon(){
        return weapons[currentWeaponIndex];
    }

    void ActivateCurrentWeapon()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(i == currentWeaponIndex);
        }
    }

}
