using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public Vector3 center;
    public Vector3 size;

    public GameObject Gameprefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnThing();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            SpawnThing();
    }

    public void SpawnThing()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));

        Instantiate(Gameprefab, pos, Quaternion.identity);
    }

    public void onDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
