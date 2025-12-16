using UnityEngine;

public static class UIWeaponHUD {
    public static void OnWeaponChanged(Weapon newWeapon) {
        Debug.Log($"HUD: Equipped {newWeapon.weaponName}");
        Debug.Log($"HUD Ammo: {newWeapon.currentAmmoInMagazine}/{newWeapon.totalAmmoReserve}");
    }

    public static void OnAmmoChanged(int current, int reserve) {
        Debug.Log($"HUD Ammo Update: {current}/{reserve}");
    }
}
