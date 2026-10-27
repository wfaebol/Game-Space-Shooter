using UnityEngine;

public class EnemyWaypointMovement : MonoBehaviour
{
    [Header("Movement Settigns")]
    [SerializeField, Min(0f)]
    float moveSpeed = 3f;

    [SerializeField, Min(0.001f)]
    float arriveDistance = 0.05f;

    [SerializeField] bool loop = false;

    private EnemyPathData pathData;
    private int currentWaypointIndex;
    private bool isMoving;

    public void Initialize(EnemyPathData path)
    {
        if (path == null || path.WaypointCount == 0)
        {
            isMoving = false;
            return;
        }

        pathData = path;
        currentWaypointIndex = 0;
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving || pathData == null) return;

        Vector3 targer = pathData.GetWaypoint(currentWaypointIndex);

        transform.position = Vector3.MoveTowards(transform.position, targer, moveSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targer);

        if (distance <= arriveDistance) MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        currentWaypointIndex++;

        if(currentWaypointIndex >= pathData.WaypointCount)
        {
            if(loop) currentWaypointIndex = 0;
            else isMoving = false;
        }
    }
}
