using UnityEngine;

public abstract class Weapon {
    public string weaponName;

    public int magazineSize;
    public int currentAmmoInMagazine;

    public int totalAmmoReserve;

    public float fireRate;    // bullets per second
    public float lastFireTime;

    public Weapon(string name, int magSize, int reserve, float rate) {
        weaponName = name;
        magazineSize = magSize;
        totalAmmoReserve = reserve;
        fireRate = rate;

        currentAmmoInMagazine = magazineSize;
        lastFireTime = -999f;
    }

    public bool CanFire() {
        if (currentAmmoInMagazine <= 0) return false;
        if (Time.time < lastFireTime + (1f / fireRate)) return false;

        return true;
    }

    public virtual void Fire() {
        if (!CanFire())
            return;

        currentAmmoInMagazine--;
        lastFireTime = Time.time;

        Debug.Log($"{weaponName} fired! Ammo left: {currentAmmoInMagazine}/{totalAmmoReserve}");

        AfterFiring();
    }

    protected abstract void AfterFiring(); // unique behavior per weapon

    public void Reload() {
        int needed = magazineSize - currentAmmoInMagazine;
        int toLoad = Mathf.Min(needed, totalAmmoReserve);

        totalAmmoReserve -= toLoad;
        currentAmmoInMagazine += toLoad;

        Debug.Log($"{weaponName} Reloaded. Mag: {currentAmmoInMagazine}, Reserve: {totalAmmoReserve}");
    }
}
