using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float enemySpawnVariance = 0.4f;
    [SerializeField] float minimumSpawnTime = 0.4f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoins = new Transform[pathPrefab.childCount]; 

        for(int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoins[i] = pathPrefab.GetChild(i);
        }

        return waypoins;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - enemySpawnVariance, timeBetweenEnemySpawn + enemySpawnVariance);

        spawnTime = Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);

        return spawnTime;
    }
}
