using UnityEngine;

// Basic rifle implementation.
// Nothing fancy here yet — mostly just plugging values into the base Weapon.
public class Rifle : Weapon {
    // Constructor just passes some defaults up the chain.
    // These numbers were tweaked a couple times until they felt “okay”.
    public Rifle() : base("Rifle", 30, 120, 10f) {
        // Intentionally empty.
        // Leaving this here in case we want per-rifle setup later.
    }

    protected override void AfterFiring() {
        // Rifle-specific behavior goes here.
        // Recoil, spread bloom, camera kick, etc.
        // For now it’s just a log so I know this is being called.
        Debug.Log("Rifle recoil applied.");

        // TODO: hook this up to actual recoil logic instead of spamming logs
    }


}