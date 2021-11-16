using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMovement : MonoBehaviour {

    public float panBorderThickness = 10f;
    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
