using System.Collections;
using System.Security;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetween = 2f;
    WaveConfigSO currentWave;


    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach(var wave in waveConfigs)
        {
            currentWave = wave;
            for(int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
            Instantiate(currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingWaypoint().position,
                Quaternion.identity,
                transform);

            yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            }

            yield return new WaitForSeconds(timeBetween);
        }
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
