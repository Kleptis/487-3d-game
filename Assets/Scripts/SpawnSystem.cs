using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public const int STARTING_GROUNDED_ENEMIES = 2;
    public const int STARTING_FLYING_ENEMIES = 1;
    private string groundedTag = "groundedEnemy";
    private string flyingTag = "flyingEnemy";
    private List<int[]> spawnPoints = new List<int[]>();
    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints.Add(new int[] { 32, 37 });
        spawnPoints.Add(new int[] { -34, 12 });
        spawnPoints.Add(new int[] { -34, 43 });
        spawnPoints.Add(new int[] { -20, 15 });
        spawnPoints.Add(new int[] { -23, 59 });
        spawnPoints.Add(new int[] { 11, 19 });
        spawnPoints.Add(new int[] { 0, 54 });
        spawnPoints.Add(new int[] { 23, 12 });
        spawnPoints.Add(new int[] { 34, 64 });
        spawnPoints.Add(new int[] { 41, 16 });

        objectPooler = ObjectPooler.Instance;

        for (int i = 0; i < STARTING_GROUNDED_ENEMIES; i++)
        {
            int[] spawnPoint = spawnPoints[Random.Range(0, 9)];
            Vector3 position = new Vector3(spawnPoint[0], 1, spawnPoint[1]);
            objectPooler.SpawnFromPool(groundedTag, position);
        }
        for (int i = 0; i < STARTING_FLYING_ENEMIES; i++)
        {
            int[] spawnPoint = spawnPoints[Random.Range(0, 9)];
            Vector3 position = new Vector3(spawnPoint[0], 12, spawnPoint[1]);
            objectPooler.SpawnFromPool(flyingTag, position);
        }
    }

    public void SpawnEnemies()
    { 
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(10f);
        int[] spawnPoint = spawnPoints[Random.Range(0, 9)];
        Vector3 position = new Vector3(spawnPoint[0], 1, spawnPoint[1]);
        objectPooler.SpawnFromPool(groundedTag, position);
        Debug.Log("Grounded Spawned");

        yield return new WaitForSeconds(5f);
        spawnPoint = spawnPoints[Random.Range(0, 9)];
        position = new Vector3(spawnPoint[0], 12, spawnPoint[1]);
        objectPooler.SpawnFromPool(flyingTag, position);
        Debug.Log("Flying Spawned");

        StartCoroutine(SpawnTimer());
    }
}
