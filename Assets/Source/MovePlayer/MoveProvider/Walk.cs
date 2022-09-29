using System;
using UnityEngine;

public class Walk : IMoveState
{
    private readonly CharacterController _characterController;
    private Speed _speed;
    private Vector3 _direction;
    public Action OnSetIdleState;

    public Walk(CharacterController characterController)
    {
        _characterController = characterController;
    }
    public void Update()
    {
        Move();
        CheckIdleState();
    }
    private void Move()
    {
        _characterController.SimpleMove(_direction * (float)_speed);
    }
    private void CheckIdleState()
    {
        if (_direction == Vector3.zero)
        {
            OnSetIdleState?.Invoke();
        }
    }
    public void SetSpeed(Speed speed)
    {
        _speed = speed;
    }
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void Start()
    {

    }

    public void Stop()
    {

    }
}