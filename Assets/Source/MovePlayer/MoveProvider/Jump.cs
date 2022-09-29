using System;
using UnityEngine;

public class Jump : IMoveState
{
    private readonly CharacterController _characterController;

    private readonly AnimationCurve _jumpCurve;
    private readonly float _startJumpTime = 0f;
    private readonly float _endJumpTime = 1f;
    private readonly float _durationCheck = 0.2f;
    private float _time = 0f;
    private Speed _lastSpeed;
    private Speed _speed;
    private JumpHight _jumpHight;
    private JumpHight _lastJumpHight;
    private Vector3 _lastDirection;
    private Vector3 _direction;

    public Action OnSetIdleState;
    public Action OnSetWalkState;
    public Jump(CharacterController characterController, AnimationCurve jumpCurve)
    {
        _characterController = characterController;
        _jumpCurve = jumpCurve;
    }
    public void Update()
    {
        if (_time <= _endJumpTime)
        {
            _time += Time.deltaTime;
            Move();
        }
        else if(_time >= _endJumpTime)
        {
            Move();
        }

        if (CheckObstaclesUnderFeet() == true)
        {
            Stop();
        }
    }
    public void Start()
    {
        _lastDirection = _direction;
        _lastSpeed = _speed;
        _lastJumpHight = _jumpHight;
    }
    public void Stop()
    {
        _time = _startJumpTime;
        WhatStateToSwitchTo();
    }
    private void WhatStateToSwitchTo()
    {
        if (_direction == Vector3.zero)
        {
            OnSetIdleState?.Invoke();
            return;
        }
        OnSetWalkState?.Invoke();
    }
    private bool CheckObstaclesUnderFeet()
    {
        return _characterController.isGrounded == true  && _time > _durationCheck ? true : false;
    }
    private void Move()
    {
        var offset = _lastDirection * (float)_lastSpeed;

        offset.y = _jumpCurve.Evaluate(_time) * ((float)_lastJumpHight * (float)_lastSpeed);
        _characterController.Move(offset * Time.deltaTime);
    }
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
    public void SetSpeed(Speed speed)
    {
        _speed = speed;
    }
    public void SetJumpHight(JumpHight jumpHight)
    {
        _jumpHight = jumpHight;
    }
}