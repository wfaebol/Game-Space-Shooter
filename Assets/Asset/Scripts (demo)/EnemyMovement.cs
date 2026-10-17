using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private enum MoveState
    {
        Entering,
        Roaming
    }

    [Header("Movement")]
    [SerializeField] private float enterSpeed = 3f;
    [SerializeField] private float roamSpeed = 2f;

    [Header("Random Movement")]
    [SerializeField] private float minChangeDirectionTime = 1f;
    [SerializeField] private float maxChangeDirectionTime = 3f;

    private MoveState currentState = MoveState.Entering;

    private Camera mainCamera;
    private Collider2D enemyCollider;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveDirection;
    private float directionTimer;

    private void Awake()
    {
        mainCamera = Camera.main;
        enemyCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void MoveInward(Vector3 direction)
    {
        direction.z = 0f;
        moveDirection = ((Vector2)direction).normalized;
        currentState = MoveState.Entering;
    }

    private void Update()
    {
        if (mainCamera == null)
            return;

        switch (currentState)
        {
            case MoveState.Entering:
                EnterCamera();
                break;

            case MoveState.Roaming:
                RoamInsideCamera();
                break;
        }
    }

    private void EnterCamera()
    {
        transform.position +=
            (Vector3)(moveDirection * enterSpeed * Time.deltaTime);

        if (IsFullyInsideCamera())
        {
            currentState = MoveState.Roaming;
            ChooseRandomDirection();
        }
    }

    private void RoamInsideCamera()
    {
        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0f)
        {
            ChooseRandomDirection();
        }

        Vector3 nextPosition = transform.position +
            (Vector3)(moveDirection * roamSpeed * Time.deltaTime);

        Bounds bounds = GetEnemyBounds();

        GetCameraBounds(
            out float left,
            out float right,
            out float bottom,
            out float top
        );

        float minX = left + bounds.extents.x;
        float maxX = right - bounds.extents.x;
        float minY = bottom + bounds.extents.y;
        float maxY = top - bounds.extents.y;

        float clampedX = Mathf.Clamp(
            nextPosition.x, minX, maxX
        );

        float clampedY = Mathf.Clamp(
            nextPosition.y, minY, maxY
        );

        if (!Mathf.Approximately(clampedX, nextPosition.x))
        {
            moveDirection.x = -moveDirection.x;
        }

        if (!Mathf.Approximately(clampedY, nextPosition.y))
        {
            moveDirection.y = -moveDirection.y;
        }

        nextPosition.x = clampedX;
        nextPosition.y = clampedY;

        transform.position = nextPosition;
    }

    private void ChooseRandomDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;

        directionTimer = Random.Range(
            minChangeDirectionTime,
            maxChangeDirectionTime
        );
    }

    private bool IsFullyInsideCamera()
    {
        Bounds bounds = GetEnemyBounds();

        GetCameraBounds(
            out float left,
            out float right,
            out float bottom,
            out float top
        );

        return bounds.min.x >= left &&
               bounds.max.x <= right &&
               bounds.min.y >= bottom &&
               bounds.max.y <= top;
    }

    private Bounds GetEnemyBounds()
    {
        if (spriteRenderer != null)
            return spriteRenderer.bounds;

        if (enemyCollider != null)
            return enemyCollider.bounds;

        return new Bounds(transform.position, Vector3.zero);
    }

    private void GetCameraBounds(
        out float left,
        out float right,
        out float bottom,
        out float top)
    {
        float depth = -mainCamera.transform.position.z;

        Vector3 bottomLeft =
            mainCamera.ViewportToWorldPoint(
                new Vector3(0f, 0f, depth)
            );

        Vector3 topRight =
            mainCamera.ViewportToWorldPoint(
                new Vector3(1f, 1f, depth)
            );

        left = bottomLeft.x;
        right = topRight.x;
        bottom = bottomLeft.y;
        top = topRight.y;
    }
}