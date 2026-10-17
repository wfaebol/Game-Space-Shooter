
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefab;
    [SerializeField] float timeSpawn = 10f;
    [SerializeField] float offsetSpawn = 1f;


    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnItem), timeSpawn, timeSpawn);
    }

    void SpawnItem()
    {
        float upY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y;

        float rightX = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;

        float leftX = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

        float randomX = Random.Range(leftX, rightX);

        Vector3 spawnPosition = new Vector3(randomX, upY + offsetSpawn, 0f);

        int randomItem = Random.Range(0, itemPrefab.Length);

        Instantiate(itemPrefab[randomItem], spawnPosition, Quaternion.identity);
    }
}
