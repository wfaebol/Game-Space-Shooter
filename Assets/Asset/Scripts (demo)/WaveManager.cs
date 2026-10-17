using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;

    [Header("Wave Settings")]
    [SerializeField] private float waveDuration = 20f;
    [SerializeField] private float baseSpawnInterval = 2f;
    [SerializeField] private float minimumSpawnInterval = 0.5f;
    [SerializeField] private float intervalDecreasePerWave = 0.2f;

    private int currentWave = 0;

    private void Start()
    {
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner is not assigned!");
            return;
        }

        StartCoroutine(WaveLoop());
    }

    private IEnumerator WaveLoop()
    {
        while (true)
        {
            currentWave++;

            Debug.Log($"Wave {currentWave} started!");

            float spawnInterval = Mathf.Max(
                minimumSpawnInterval,
                baseSpawnInterval -
                intervalDecreasePerWave * (currentWave - 1)
            );

            float elapsed = 0f;

            while (elapsed < waveDuration)
            {
                enemySpawner.SpawnEnemy();

                float waitTime = Mathf.Min(
                    spawnInterval,
                    waveDuration - elapsed
                );

                yield return new WaitForSeconds(waitTime);

                elapsed += waitTime;
            }

            Debug.Log($"Wave {currentWave} ended!");
        }
    }
}