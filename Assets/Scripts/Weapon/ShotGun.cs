using UnityEngine;

// Shotgun implementation.
// Short range, low ammo, lots of damage (at least on paper).
public class Shotgun : Weapon {
    // Pass shotgun-specific values to the base Weapon.
    // Fire rate is intentionally low — any faster felt wrong.
    public Shotgun() : base("Shotgun", 8, 32, 1f) {
        
        
    }

    protected override void AfterFiring() {
        // This is where pellet logic *should* live eventually.
        // Right now it’s just a placeholder so I know it fired.
        Debug.Log("Shotgun pellets fired.");

        // Note to self: this should probably trigger multiple raycasts, not one.
    }


}