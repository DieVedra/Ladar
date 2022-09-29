using System;
using UnityEngine;

public class StateSwitch
{
    private readonly Jump _jump;
    private readonly Walk _walk;
    private readonly Idle _idle;
    private IMoveState _currentState;

    public Action<IMoveState> OnStateChange;
    public IMoveState CurrentState => _currentState;
    public StateSwitch(Jump jump, Walk walk, Idle idle)
    {
        _jump = jump;
        _walk = walk;
        _idle = idle;
        _jump.OnSetIdleState += FromJumpToIdle;
        _jump.OnSetWalkState += FromJumpToWalk;
        _idle.OnSetWalkState += FromIdleToWalk;
        _walk.OnSetIdleState += FromWalkToIdle;
    }

    public void FromIdleToWalk()
    {
        if (_currentState is Idle)
        {
            SetCurrentState(_walk);
        }
    }
    public void FromWalkToIdle()
    {
        if (_currentState is Walk)
        {
            SetCurrentState(_idle);
        }
    }
    public void ToJump()
    {
        if (_currentState is Jump)
        {
            return;
        }
        SetCurrentState(_jump);
    }
    public void FromJumpToWalk()
    {
        if (_currentState is Jump)
        {
            SetCurrentState(_walk);
        }
    }
    public void FromJumpToIdle()
    {
        if (_currentState is Jump)
        {
            SetCurrentState(_idle);
        }
    }
    public void SetIdleState()
    {
        SetCurrentState(_idle);
    }
    private void SetCurrentState(IMoveState state)
    {
        if (state == _jump)
        {
            _jump.Start();
        }
        _currentState = state;
        OnStateChange?.Invoke(_currentState);
    }
}