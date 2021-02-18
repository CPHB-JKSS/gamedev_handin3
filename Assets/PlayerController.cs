using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {

        /*if (Input.GetKey(KeyCode.LeftArrow)) {
            rotation-= 5;
        }
        
        if (Input.GetKey(KeyCode.RightArrow)) {
            rotation+= 5;
        }

        Debug.Log("Rotation: " + rotation);
        rb.MoveRotation(new Quaternion(0,rotation,0,1));*/

        float moveHorizontal = Input.GetAxis("Horizontal");        
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);      
    }
}