using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    [SerializeField]
    private Transform targetPosition;
    private bool fixedCamera;

	// Use this for initialization
	void Start () {
        fixedCamera = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Camera movement
        if (fixedCamera) {
            transform.position = targetPosition.position;
        } else
        {
            if(Input.GetAxis("Horizontal") > 0.1)
            {
                transform.position += transform.TransformDirection(Vector3.right) * 10 * Time.fixedDeltaTime;
            } else if(Input.GetAxis("Horizontal") < -0.1)
            {
                transform.position += -transform.TransformDirection(Vector3.right) * 10 * Time.fixedDeltaTime;
            }

            if (Input.GetAxis("Vertical") > 0.1f)
            {
                transform.position += transform.TransformDirection(Vector3.forward) * 10 * Time.fixedDeltaTime;
            }
            else if (Input.GetAxis("Vertical") < -0.1f)
            {
                transform.position += -transform.TransformDirection(Vector3.forward) * 10 * Time.fixedDeltaTime;
            }
        }

        //Change camera mode between fixed to character and free
        if (Input.GetKeyDown(KeyCode.F))
        {
            fixedCamera = !fixedCamera;
        }

        //Camera Rotation
        if(Input.GetAxis("Rotate") < 0 || Input.GetAxis("Rotate") > 0)
        {
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Rotate") * 50 * Time.fixedDeltaTime, 0);
        }
	}
}
