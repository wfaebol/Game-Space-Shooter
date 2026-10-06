using UnityEngine;
using UnityEngine.Timeline;

public class Pathfinding : MonoBehaviour
{
    EnemySpawn enemySpawn;
    WaveConfigSO waveConfig;
    Transform[] waypoints;
    int waypointIndex = 0;


    void Start()
    {
        enemySpawn = FindFirstObjectByType<EnemySpawn>();
        waveConfig = enemySpawn.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDelta);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
