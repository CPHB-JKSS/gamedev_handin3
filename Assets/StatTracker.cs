using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatTracker : MonoBehaviour
{

    public GameObject startZone, endZone;
    private TimerState timer;


    void OnTriggerEnter(Collider collider) {
        // If entering endzone
        if (collider.gameObject.name == endZone.name) { 
            Debug.Log(timer.deltaTime);
        }



        Debug.Log("Enter: " + collider.gameObject.name);
    }

    void OnTriggerStay(Collider collider) {

    }

    void OnTriggerExit(Collider collider) {
        // If exitting startzone
        if (collider.gameObject.name == startZone.name) { 
            Debug.Log(timer.now);


            Debug.Log("Exit: " + collider.gameObject.name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
