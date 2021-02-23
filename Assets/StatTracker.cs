using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class StatTracker : MonoBehaviour
{

    public GameObject startZone, endZone;
    private bool timerGoing;
    private float elapsedTime;


    void OnTriggerEnter(Collider collider) {
        // If entering startZone
        if (collider.gameObject.name == startZone.name) {
            timerGoing = false;
            elapsedTime = 0f;
        }

        // If entering endZone
        if (collider.gameObject.name == endZone.name) {
            timerGoing = false;
            Debug.Log("Time spent: " + elapsedTime);
        }
        Debug.Log("Enter: " + collider.gameObject.name);
    }

    void OnTriggerStay(Collider collider) {
        // If entering endZone
        if (collider.gameObject.name == endZone.name) {

        }
    }

    void OnTriggerExit(Collider collider) {
        // If exitting startZone
        if (collider.gameObject.name == startZone.name) { 
            timerGoing = true;

            Debug.Log("Exit: " + collider.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timerGoing) {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
        }
    }
}
