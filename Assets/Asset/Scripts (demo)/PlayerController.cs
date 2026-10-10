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


    Shooter PlayerShooter;
    InputAction moveAction;
    InputAction fireAction;
    Vector3 moveVector;
    Vector3 minPos;
    Vector3 maxPos;


    void Start()
    {
        PlayerShooter = GetComponent<Shooter>();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Attack");
        InitBounds();
    }

    void Update()
    {
        MovePlayer();
        FireShooter();
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
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 positionPlayer = transform.position + moveVector * moveSpeed * Time.deltaTime;
        positionPlayer.x = Math.Clamp(positionPlayer.x, minPos.x + leftBound, maxPos.x - rightBound);
        positionPlayer.y = Math.Clamp(positionPlayer.y, minPos.y + downBound, maxPos.y - upBound);

        transform.position = positionPlayer;
    }

    void FireShooter()
    {
        PlayerShooter.isFiring = fireAction.IsPressed();
    }
}
