using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {


    public float moveSpeed = 5.0f;
    public float drag = 5f;
    public VirtualJoystick moveJoystick;
    private Rigidbody2D controller;
    private Transform camTransform;

    private void Start() {

        controller = GetComponent <Rigidbody2D> ();
        controller.drag = drag;
        camTransform = Camera.main.transform;

    }


    private void Update() {

        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis ("Horizontal");
        dir.y = Input.GetAxis ("Vertical");

        if (dir.magnitude > 1) 

            dir.Normalize();

        if (moveJoystick.InputDirection != Vector3.zero)
        {

            dir = moveJoystick.InputDirection;
        }

        //Rotate our direction vector with camera
        Vector3 rotateDir = camTransform.TransformDirection (dir);
        rotateDir = new Vector3 (rotateDir.x, rotateDir.z, 0);
        rotateDir = rotateDir.normalized * dir.magnitude;

        controller.AddForce (rotateDir * moveSpeed);



    }
}
