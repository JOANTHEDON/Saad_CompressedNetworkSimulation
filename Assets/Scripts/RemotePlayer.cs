using UnityEngine;

// Represents the other player on the network.
// This one just smoothly follows whatever data it last received.
public class RemotePlayer : MonoBehaviour {
    private Vector3 targetPos; // Where we want to be
    private Vector3 startPos; // Initial spawn position, used as a base

    void Start() {
        startPos = transform.position;
        targetPos = startPos; // Prevents weird snapping on the first update
    }

    void Update() {
        // Simple smoothing — nothing fancy like prediction yet
        
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * 5f
        );
    }

    public void ReceiveData(ushort x, ushort y, ushort z) {
        // Decompress incoming values
        float dx = PositionCompressor.Decompress(x);
        float dy = PositionCompressor.Decompress(y); // Currently unused
        float dz = PositionCompressor.Decompress(z);

        // Keep the remote player on the ground.
        // Y was causing weird floating before, so just zero it out.
        // Using startPos as a reference felt safer than absolute world coords.
        targetPos = startPos + new Vector3(dx, 0f, dz);

        // Helpful during testing to make sure values look sane
        Debug.Log(
            "[RECEIVED] Offset XZ: (" +
            dx.ToString("F2") + ", " +
            dz.ToString("F2") + ")"
        );

        
    }


}