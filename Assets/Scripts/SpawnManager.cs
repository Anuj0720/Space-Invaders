using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnPosX = 58;
    private float spawnPosZ = 35;

    private float startDelay = 1f;
    private float repeatTimer = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn Enemies for every 2 seconds
        InvokeRepeating("SpawnEnemy", startDelay, repeatTimer);
    }

    void SpawnEnemy(){
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        float randomPosX = Random.Range(-spawnPosX, spawnPosX);
        Vector3 spawnPos = new Vector3(randomPosX, 0, spawnPosZ);

        // Make Multiple enemies
        Instantiate(enemyPrefabs[randomIndex], spawnPos, enemyPrefabs[randomIndex].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
