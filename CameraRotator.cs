using UnityEngine;

public class CameraRotator : MonoBehaviour {
    
    public Transform xFormParent;

    private Vector3 rotation;

    public float mouseSensitivity = 4f;
    public float rotationDampening = 10f;

    public bool CameraDisabled = true; // Camera won't move unless declared as false!

    [Header("Rotation Limit")]
    public float minPos;
    public float maxPos;

    [Header("Changing target")]
    public Transform target;
    public float smoothTime;
    Vector3 velocity = Vector3.zero;
    public bool changed;
    float dist;

    // Use this for initialization
    void Start () {
        this.xFormParent = this.transform.parent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeTarget();
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            CameraDisabled = false;
        }
        if (!Input.GetKey(KeyCode.Mouse2))
        {
            CameraDisabled = true;
        }
        if (changed == true)
        {
            xFormParent.position = Vector3.SmoothDamp(xFormParent.position, target.position, ref velocity, smoothTime);
            dist = Vector3.Distance(xFormParent.position, target.position);
            if (dist < 0.025f)
            {
                xFormParent.position = target.position;
                changed = false;
            }
        }
    }

    // Late Update is called once per frame, after Update () on every game object in the scene.
    void LateUpdate () {
        if (!CameraDisabled)
        {
            //Rotation of the camera based on mouse position.
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                rotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                rotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                //Clamp the y Rotation to 0 and not flipping over at the top.
                rotation.y = Mathf.Clamp(rotation.y, minPos, maxPos);
            }

        }

        //Actual Camera Rig Transformation

        //Rotation Rig! Transform the camera on x/y axis.
        Quaternion QT = Quaternion.Euler(rotation.y, rotation.x, 0);
        this.xFormParent.rotation = Quaternion.Lerp(this.xFormParent.rotation, QT, Time.deltaTime * rotationDampening);

	}
    
    public void ChangeTarget ()
    {
        changed = true;
    }
    
}
