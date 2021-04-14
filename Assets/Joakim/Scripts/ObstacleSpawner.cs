using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class ObstacleSpawner : MonoBehaviour
{
    Renderer rend;

    [SerializeField]
    public Vector3 center, size;
    public float obstacleSizeMultiplier;

    [SerializeField]
    public int objectsToGenerate = 1;
    //public GameObject obj;
    public List<GameObject> objectsList;

    [SerializeField]
    private Collider2D[] colliders;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        NavMeshBuilder.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateLevel()
    {
        for (int i = 0; i < objectsToGenerate; i++)
        {
            SpawnObject(objectsList[Random.Range(0, objectsList.Count)]); //Parse random object from list
        }
    }

    void SpawnObject(GameObject obj)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        float spawnPosX = Random.Range(-size.x / 2, size.x / 2);
        float spawnPosZ = Random.Range(-size.z / 2, size.z / 2);
        pos = center + new Vector3(spawnPosX, 0, spawnPosZ);
        /*bool canSpawnHere = false;
        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(-size.x / 2, size.x / 2);
            float spawnPosZ = Random.Range(-size.z / 2, size.z / 2);
            pos = center + new Vector3(spawnPosX, 0, spawnPosZ);
            canSpawnHere = PreventSpawnOverlap(pos);

            if (canSpawnHere)
            {
                break;
            }
        }*/

        GameObject newObj = Instantiate(obj, pos, Quaternion.identity);
        newObj.transform.localScale = new Vector3(Random.Range(0.2f, 4) * obstacleSizeMultiplier, 1, Random.Range(0.2f, 4) * obstacleSizeMultiplier);

        rend = newObj.GetComponent<Renderer>();

        rend.bounds.extents.Set(rend.bounds.extents.x, 0.5f, rend.bounds.extents.z); //TODO, supposed to set the height of all objects to exactly 0.5f. Does not work because it's read-only.
        //Debug.Log(rend.bounds.extents);
    }

    bool PreventSpawnOverlap(GameObject obj)
    {

        colliders = Physics2D.OverlapBoxAll(obj.transform.position, transform.localScale / 2, obj.transform.rotation.y, 0);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float length = colliders[i].bounds.extents.z;

            float westExtent = centerPoint.x - width;
            float eastExtent = centerPoint.x + width;
            float southExtent = centerPoint.x - length;
            float northExtent = centerPoint.x - length;

            if (obj.transform.position.x >= westExtent && obj.transform.position.x <= eastExtent)
            {
                if (obj.transform.position.y >= southExtent && obj.transform.position.y <= northExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void FixCollision(GameObject obj)
    {
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0.8f, 0, 0.3f);
        Gizmos.DrawCube(center, size);
    }
}
