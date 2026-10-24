using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftBound;
    [SerializeField] float rightBound;
    [SerializeField] float upBound;
    [SerializeField] float downBound;
    [SerializeField] VariableJoystick joystick;
    [SerializeField] InputActionReference touchPress;
    [SerializeField] InputActionReference touchPosition;


    Vector3 minPos;
    Vector3 maxPos;
    Camera mainCamera;
    bool isTouching;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        if (touchPress == null || touchPosition == null)
            return;

        touchPress.action.Enable();
        touchPosition.action.Enable();

        touchPress.action.started += OnTouchStarted;
        touchPress.action.canceled += OnTouchCanceled;
    }

    private void OnDisable()
    {
        if(touchPress != null)
        {
            touchPress.action.started -= OnTouchStarted;
            touchPress.action.canceled -= OnTouchCanceled;
            touchPress.action.Disable();
        }

        if (touchPosition != null)
            touchPosition.action.Disable();

        isTouching = false;
    }


    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    void OnTouchStarted(InputAction.CallbackContext context) => isTouching = true;

    void OnTouchCanceled(InputAction.CallbackContext context) => isTouching = false;


    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        float zCamera = -mainCamera.transform.position.z;
        minPos = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, zCamera));
        maxPos = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, zCamera));
    }

    void MovePlayer()
    {
        if(!isTouching || mainCamera == null || touchPosition == null) return;

        Vector2 screenPosition = touchPosition.action.ReadValue<Vector2>();

        float zCamera = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);

        Vector3 targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, zCamera));

        targetPosition.z = transform.position.z;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x + leftBound, maxPos.x - rightBound);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y + downBound, maxPos.y - upBound);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
