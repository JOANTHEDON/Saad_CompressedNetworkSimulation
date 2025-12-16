using UnityEngine;

// Static helper for squishing world positions into something cheaper to send.
// Assumes positions will never go outside this range (famous last words).
public static class PositionCompressor {
    // Hard limits for the world.
    // If someone walks past these, things will break in subtle ways.
    private const float MinValue = -100f;
    private const float MaxValue = 100f;

    public static ushort Compress(float value) {
        // Clamp just in case — not strictly necessary,
        // but I don’t trust input values 100%.
        float clamped = Mathf.Clamp(value, MinValue, MaxValue);

        // Normalize into 0..1 range
        float normalized = Mathf.InverseLerp(MinValue, MaxValue, clamped);

        // Convert to ushort range
        // Precision loss is expected and accepted here
        ushort compressed = (ushort)(normalized * ushort.MaxValue);

        return compressed;
    }

    public static float Decompress(ushort value) {
    
        float normalized = value / (float)ushort.MaxValue;

        
        float decompressed = Mathf.Lerp(MinValue, MaxValue, normalized);

        return decompressed;
    }

    


}