using UnityEngine;


public class StatTracker : MonoBehaviour
{
    private bool timerGoing;
    private float elapsedTime;
    public GameObject startZone, endZone, walls;
    //private TimerState timer;
    public int wallHits, ballHits;

    public int counterWalls;
    public int counterBalls;

    public ObjectSpawner spawner;

    void OnCollisionEnter(Collision collider)
    {

        if ((collider.gameObject.name.Contains("Wall") || collider.gameObject.name.Contains("Cylinder")) && timerGoing)
        {
            wallHits++;
            spawner.SpawnThing();
            //Debug.Log(walls.gameObject.name + " HIT! oof...");
            counterWalls++;
            Debug.Log(itemsHit());
        }

        if (collider.gameObject.name.Contains("EnemyBall"))
        {
            ballHits++;
            counterBalls++;
            Debug.Log(itemsHit());
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        // If entering startZone
        if (collider.gameObject.name == startZone.name)
        {
            timerGoing = false;
            elapsedTime = 0f;
        }

        // If entering endZone
        if (collider.gameObject.name == endZone.name)
        {
            timerGoing = false;
            //Debug.Log("Time spent: " + elapsedTime);
            //Debug.Log("Walls hit: " + wallHits);
            Debug.Log(Score());
        }
        //Debug.Log("Enter: " + collider.gameObject.name);
    }

    void OnTriggerExit(Collider collider)
    {
        // If exitting startZone
        if (collider.gameObject.name == startZone.name)
        {
            timerGoing = true;
            wallHits = 0;
            ballHits = 0;
            //Debug.Log("Exit: " + collider.gameObject.name);
        }
    }

    string itemsHit()
    {
        return "Walls hit: " + counterWalls + " Balls hit: " + counterBalls;
    }
    string Score()
    {

        return "Final score:" + (1000 - (elapsedTime + (wallHits * 3) + (ballHits * 3))).ToString("0");
    }


    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log(elapsedTime);
        }
    }
}
