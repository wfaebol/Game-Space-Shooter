using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnOffset = 0.05f;
    [SerializeField] private Transform enemyContainer;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void SpawnEnemy()
    {
        if (mainCamera == null || enemyPrefab == null)
        {
            Debug.LogError("Missing Camera or Enemy Prefab!");
            return;
        }

        int edge = Random.Range(0, 4);
        Vector2 viewportPosition;

        switch (edge)
        {
            case 0: // Trên
                viewportPosition = new Vector2(
                    Random.Range(0f, 1f),
                    1f + spawnOffset
                );
                break;

            case 1: // Dưới
                viewportPosition = new Vector2(
                    Random.Range(0f, 1f),
                    -spawnOffset
                );
                break;

            case 2: // Trái
                viewportPosition = new Vector2(
                    -spawnOffset,
                    Random.Range(0f, 1f)
                );
                break;

            default: // Phải
                viewportPosition = new Vector2(
                    1f + spawnOffset,
                    Random.Range(0f, 1f)
                );
                break;
        }

        float depth = -mainCamera.transform.position.z;

        Vector3 spawnPosition =
            mainCamera.ViewportToWorldPoint(
                new Vector3(
                    viewportPosition.x,
                    viewportPosition.y,
                    depth
                )
            );

        spawnPosition.z = 0f;

        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity,
            enemyContainer
        );

        Vector3 center = mainCamera.ViewportToWorldPoint(
            new Vector3(0.5f, 0.5f, depth)
        );

        center.z = 0f;

        EnemyMovement movement =
            enemy.GetComponent<EnemyMovement>();

        if (movement != null)
        {
            movement.MoveInward(center - spawnPosition);
        }
        else
        {
            Debug.LogWarning(
                "Enemy Prefab is missing EnemyMovement!"
            );
        }
    }
}
