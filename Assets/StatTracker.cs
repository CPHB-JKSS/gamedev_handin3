using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatTracker : MonoBehaviour
{

    public GameObject startZone, endZone, walls;
    //private TimerState timer;
    public bool gameStarted;
    public float gameTimer;
    public int wallHits;

    void OnCollisionEnter(Collision collider)
    {

        if ((collider.gameObject.name.Contains("Wall") || collider.gameObject.name.Contains("Cylinder")) && gameStarted)
        {
            wallHits++;
            Debug.Log(walls.gameObject.name + " HIT! oof...");
        }

        //Debug.Log("COLLISION: " + collider.gameObject.name);
    }
    void OnTriggerEnter(Collider collider)
    {
        // If entering endzone
        if (collider.gameObject.name == endZone.name && gameStarted)
        {
            //Debug.Log(timer.deltaTime);
            gameStarted = false;

            Debug.Log("Game ended!");
            Debug.Log("Game lasted: " + gameTimer);
            Debug.Log("Walls hit: " + wallHits);
        }

        
        //Debug.Log("Enter: " + collider.gameObject.name);
    }

    void OnTriggerStay(Collider collider)
    {

    }

    void OnTriggerExit(Collider collider)
    {
        // If exitting startzone
        if (collider.gameObject.name == startZone.name && !gameStarted)
        {
            gameStarted = true;
            Debug.Log("Game started!");


            //Debug.Log("Exit: " + collider.gameObject.name);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0;
        gameStarted = false;
        wallHits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            gameTimer++;
        }

    }
}
