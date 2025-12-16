using UnityEngine;


public class MyPlayer : MonoBehaviour {
    public RemotePlayer remotePlayer;
    public float speed = 5f; 

    private Vector3 lastSentPos;          
    private Vector3 startPos;             

    void Start() {
        startPos = transform.position;
        lastSentPos = startPos; 
    }

    void Update() {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 moveDir = new Vector3(horizontal, 0f, vertical);
        transform.position += moveDir * speed * Time.deltaTime;

        
        SendCompressedPosition();
    }

    void SendCompressedPosition() {
        Vector3 currentPos = transform.position;

      
        float dist = Vector3.Distance(lastSentPos, currentPos);
        if (dist < 0.02f) {
            return;
        }

        
        lastSentPos = currentPos;

      
        ushort cx = PositionCompressor.Compress(currentPos.x);
        ushort cy = PositionCompressor.Compress(currentPos.y);
        ushort cz = PositionCompressor.Compress(currentPos.z);

        
        int bitSize = 16 * 3;

        Debug.Log(
            "[SENT] Pos: " + currentPos +
            " | Size: " + bitSize + " bits"
        );

        
        if (remotePlayer != null) {
            remotePlayer.ReceiveData(cx, cy, cz);
        }
        else {
            
            Debug.LogWarning("RemotePlayer not assigned!");
        }

       
    }


}