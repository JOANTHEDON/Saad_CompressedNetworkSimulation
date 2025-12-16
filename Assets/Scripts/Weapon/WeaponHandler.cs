using UnityEngine;

public class WeaponHandler {
    public Weapon primaryWeapon1;
    public Weapon primaryWeapon2;
    public Weapon secondaryWeapon;

    public Weapon currentWeapon;

    public void EquipPrimary1() {
        currentWeapon = primaryWeapon1;
        Debug.Log("Equipped Primary 1: " + currentWeapon.weaponName);
    }

    public void EquipPrimary2() {
        currentWeapon = primaryWeapon2;
        Debug.Log("Equipped Primary 2: " + currentWeapon.weaponName);
    }

    public void EquipSecondary() {
        currentWeapon = secondaryWeapon;
        Debug.Log("Equipped Secondary: " + currentWeapon.weaponName);
    }
}
