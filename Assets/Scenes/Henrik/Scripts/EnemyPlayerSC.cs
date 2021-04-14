using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerSC : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent = null;

    GameObject ball;

    Vector3 targetPos;

    public GameObject explosion;

    void OnCollisionEnter(Collision collider)
    {
        // Check the bot has collided with player
        if (collider.gameObject.name.Contains("PlayerBall"))
        {
            // Instantiate Explosion
            Instantiate(explosion, transform.position, transform.rotation);

            // Destroy the gameobject
            Destroy(gameObject);
        }
    }

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ball = GameObject.Find("PlayerBall"); // dårlig stil!
    }

    void Update()
    {
        targetPos = ball.transform.position;
        navMeshAgent.SetDestination(targetPos);

    }

}

