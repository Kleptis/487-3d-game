using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public const int STARTING_GROUNDED_ENEMIES = 5;
    public const int STARTING_FLYING_ENEMIES = 3;
    private string groundedTag = "groundedEnemy";
    private string flyingTag = "flyingEnemy";
    private List<int[]> spawnPoints = new List<int[]>();
    private List<int[]> initialSpawns = new List<int[]>();
    [SerializeField] private Mesh[] kanjiMeshList;
    private Mesh kanjiMesh;

    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        Spawning();
        looper(initialSpawns, STARTING_GROUNDED_ENEMIES, groundedTag, 0);
        looper(initialSpawns, STARTING_FLYING_ENEMIES, flyingTag, 12);
    }
    void looper(List<int[]> spawnList, int spawnListCount, string tag, int yPos)
    {
        for (int i = 0; i < spawnListCount; i++)
        {
        int j = spawnList.Count;
        int[] spawnPoint = spawnList[Random.Range(0, j)];
        Vector3 position = new Vector3(spawnPoint[0], yPos, spawnPoint[1]);
        kanjiMesh = kanjiMeshList[Random.Range(0, kanjiMeshList.Length)];
        objectPooler.SpawnFromPool(tag, position, kanjiMesh);
        spawnList.Remove(spawnPoint);
        }
    }

    public void SpawnEnemies(Component sender, object data)
    {
        if ((int)data < 0)
        {
            StartCoroutine(SpawnTimer());
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(10f);
        int[] spawnPoint = spawnPoints[Random.Range(0, 9)];
        Vector3 playerPos = player.transform.position;
        Vector3 spawn = new Vector3(spawnPoint[0], 0, spawnPoint[1]);

        while (Vector3.Distance(playerPos, spawn) < 15f)
        {
            spawnPoint = spawnPoints[Random.Range(0, 9)];
            spawn = new Vector3(spawnPoint[0], 0, spawnPoint[1]);
        }

        kanjiMesh = kanjiMeshList[Random.Range(0, kanjiMeshList.Length)];
        objectPooler.SpawnFromPool(groundedTag, spawn, kanjiMesh);
        
        Debug.Log("Grounded Spawned");

        yield return new WaitForSeconds(5f);
        spawnPoint = spawnPoints[Random.Range(0, 9)];
        spawn = new Vector3(spawnPoint[0], 12, spawnPoint[1]);
        kanjiMesh = kanjiMeshList[Random.Range(0, kanjiMeshList.Length)];
        objectPooler.SpawnFromPool(flyingTag, spawn, kanjiMesh);
        Debug.Log("Flying Spawned");

        StartCoroutine(SpawnTimer());
    }
    void Spawning()
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
        initialSpawns.Add(new int[] { 32, 37 });
        initialSpawns.Add(new int[] { -34, 12 });
        initialSpawns.Add(new int[] { -34, 43 });
        initialSpawns.Add(new int[] { -20, 15 });
        initialSpawns.Add(new int[] { -23, 59 });
        initialSpawns.Add(new int[] { 11, 19 });
        initialSpawns.Add(new int[] { 0, 54 });
        initialSpawns.Add(new int[] { 23, 12 });
        initialSpawns.Add(new int[] { 34, 64 });
        initialSpawns.Add(new int[] { 41, 16 });
    }


}


