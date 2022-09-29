using System;
using UnityEditor;
using UnityEngine;

public class Idle : IMoveState
{
    private readonly CharacterController _characterController;
    public Action OnSetWalkState;
    private Vector3 _direction;

    public Idle(CharacterController characterController)
    {
        _characterController = characterController;
    }
    public void Start()
    {

    }

    public void Stop()
    {

    }

    public void Update()
    {
        CheckWalkState();
    }
    private void CheckWalkState()
    {
        if (_direction != Vector3.zero)
        {
            OnSetWalkState?.Invoke();
        }
    }
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}