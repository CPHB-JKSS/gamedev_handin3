using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public float scrollMax = 6.0f;
    public float scrollMin = 1.4f;
    public float angleMax = 85f;
    public float angleMin = -3f;

    private Transform _myTransform;
    private float x;
    private float y;

    void Start()
    {
        if (target == null)
            Debug.Log("PlayerBall not found...");

        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Scroll funktion, < betyder scroll baglens, > betyder scroll forlæns.
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && distance < scrollMax)
            distance += 0.1f;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && distance > scrollMin)
            distance -= 0.1f;
    }

    void LateUpdate()
    {

        //hastigheden på scrolling, - på y for "ikke inverse" scrolling
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
        y += Input.GetAxis("Mouse Y") * ySpeed * -0.02f;

        // min og maks vinkler på kameraet
        if (y >= angleMax)
            y = angleMax;
        if (y <= angleMin)
            y = angleMin;


        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;


        _myTransform.rotation = rotation;
        _myTransform.position = position;
    }

}
