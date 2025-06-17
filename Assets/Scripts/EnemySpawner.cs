using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves()); // starts a coroutine to handle spawning enemy waves
    }

    // Update is called once per frame
    void Update()
    {

    }

    public WaveConfigSO GetCurrentWave() // This method returns the current wave configuration (currentWave)
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves() // defines a coroutine that spawns enemy waves
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs) // iterates over each wave configuration in waveConfigs
            {
                currentWave = wave; // sets currentWave to the current wave configuration in the loop
                for (int i = 0; i < currentWave.GetEnemyCount(); i++) // loops through the number of enemies specified in the current wave
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), // Instantiate creates a new instance of the enemy prefab. currentWave.GetEnemyPrefab(i) gets the enemy prefab to instantiate for the i-th enemy
                            currentWave.GetStartingWaypoint().position, // sets the position where the enemy will be spawned (the position of the starting waypoint)
                            Quaternion.Euler(0, 0, 180), // For each enemy, it instantiates the enemy prefab at the starting waypoint's position with a rotation of 180 degrees on the Z-axis
                            transform); // sets the parent of the instantiated enemy to the EnemySpawner object

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime()); // This pauses the coroutine for a random amount of time (determined by GetRandomSpawnTime) before spawning the next enemy
                }
                yield return new WaitForSeconds(timeBetweenWaves); // And this pauses the coroutine for the specified timeBetweenWaves before starting the next wave
            }
        } while (isLooping);
    }
}
