using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOld : MonoBehaviour
{

    public Rigidbody rb;
    public float playerFacing = 0f;
    public float turnSpeed = 3f;
    void start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        
         if (Input.GetKey(KeyCode.A))
             rb.AddForce(Vector3.left);
         if (Input.GetKey(KeyCode.D))
             rb.AddForce(Vector3.right);
         if (Input.GetKey(KeyCode.W))
             rb.AddForce(Vector3.forward);
         if (Input.GetKey(KeyCode.S))
             rb.AddForce(Vector3.back);

         if (Input.GetKey(KeyCode.Q))
            playerFacing -= 1f;
            rb.transform.Rotate(playerFacing * turnSpeed * Vector3.up, Space.World);
    }
}
