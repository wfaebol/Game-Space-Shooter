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


    Rigidbody2D rb;
    Vector3 minPos;
    Vector3 maxPos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        float zCamera = -mainCamera.transform.position.z;
        minPos = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, zCamera));
        maxPos = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, zCamera));
    }

    void MovePlayer()
    {
        Vector3 direction = Vector3.up * joystick.Vertical + Vector3.right * joystick.Horizontal;
        Vector3 positionPlayer = transform.position + direction * moveSpeed * Time.deltaTime;
        positionPlayer.x = Mathf.Clamp(positionPlayer.x, minPos.x + leftBound, maxPos.x - rightBound);
        positionPlayer.y = Mathf.Clamp(positionPlayer.y, minPos.y + downBound, maxPos.y - upBound);

        transform.position = positionPlayer;
    }
}
