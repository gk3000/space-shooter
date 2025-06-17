using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float moveSpeed = 10;

    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()  // This method returns the first child of the pathPrefab transform
    {
        return pathPrefab.GetChild(0); // gets the first child transform
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>(); // creates an empty list to hold the waypoints
        foreach (Transform child in pathPrefab) // iterates over each child transform in pathPrefab
        {
            waypoints.Add(child); // adds each child transform to the list
        }
        return waypoints; // returns the list of waypoints
    }

    public int GetEnemyCount() // This method returns the number of enemy prefabs in the enemyPrefabs list
    {
        return enemyPrefabs.Count; // returns the count of elements in the enemyPrefabs list
    }
    public GameObject GetEnemyPrefab(int index) // This method returns the enemy prefab at the specified index in the enemyPrefabs list
    {
        return enemyPrefabs[index]; // returns the GameObject (enemyPrefab) at the specified index
    }

    public float GetMoveSpeed() // This method returns the moveSpeed value
    {
        return moveSpeed; // returns the moveSpeed field's value
    }

    public float GetRandomSpawnTime() // This method calculates a random spawn time for enemies, ensuring variability within defined limits
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance); // This line calculates a random float between timeBetweenEnemySpawns - spawnTimeVariance and timeBetweenEnemySpawns + spawnTimeVariance. Random.Range generates a random float within the specified range.
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue); // This line ensures that the calculated spawn time is at least minimumSpawnTime. Mathf.Clamp restricts the value of spawnTime to be between minimumSpawnTime and float.MaxValue.
    }
}
