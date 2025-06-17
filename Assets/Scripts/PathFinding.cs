using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawner enemySpawner; // reference to the EnemySpawner component in the scene
    WaveConfigSO waveConfig;

    List<Transform> waypoints;
    int waypointIndex = 0; // default waypoint

    // The Awake method is called when the script instance is being loaded
    void Awake()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>(); //  finds and assigns the EnemySpawner component in the scene to EnemySpawner
    }
    // Using enemySpawner = FindFirstObjectByType<EnemySpawner>();
    // in Awake ensures the enemySpawner reference is initialized before any Start methods run,
    // preventing potential null reference errors.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave(); //gets the current wave configuration from the EnemySpawner
        waypoints = waveConfig.GetWaypoints(); // gets the list of waypoints from the waveConfig
        transform.position = waypoints[waypointIndex].position; // sets the initial position of the game object (Enemy) to the position of the first waypoint
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count) // Checks if there are more waypoints to move to
        {
            Vector3 targetPosition = waypoints[waypointIndex].position; // gets the position of the current target waypoint
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; // calculates the distance to move this frame based on the move speed and the time elapsed since the last frame
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta); // moves the game object towards the target position
            if (transform.position == targetPosition) // Checks if the game object has reached the target waypoint
            {
                waypointIndex++; // increments the waypoint index to move to the next waypoint
            }
        }
        else // If all waypoints have been reached
        {
            Destroy(gameObject); // Destroys the game object (Enemy)
        }
    }
}
