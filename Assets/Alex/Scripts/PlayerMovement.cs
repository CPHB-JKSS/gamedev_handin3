using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 5f;

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(moveSpeed * transform.forward);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce(moveSpeed * -transform.forward);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(turnSpeed * -Vector3.up, Space.World);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(turnSpeed * Vector3.up, Space.World);


    }


    /*
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.forward);

        if (Input.GetKey(KeyCode.S))
            transform.Rotate(Time.deltaTime * turnSpeed * -Vector3.forward);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.down);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);

    }
    */
}
