using UnityEngine;

public class CameraController : MonoBehaviour {

    public float scrollSpeed = 2f;
    public float minY = 1.5f;
    public float maxY = 50f;

    public float dragSpeed;

    public Vector3 startPosition;
    public Vector3 pos;
    
    public GameObject CameraHolder;
       
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        pos = transform.position;
                
        if (Input.GetKeyDown(KeyCode.Z))
            transform.position = startPosition;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (pos.y >= minY && scroll > 0 || pos.y <= maxY && scroll < 0)
        {
            transform.Translate(0, 0, scroll * scrollSpeed * Time.deltaTime);
        }
        
        // Right Click to move Camera.
        if (Input.GetMouseButton (1))
        {
            float h = dragSpeed * Input.GetAxis("Mouse Y");
            float v = dragSpeed * Input.GetAxis("Mouse X");
            CameraHolder.transform.Translate(-v,0,-h); // Attached to Camera Holder!
        }
    }

}
