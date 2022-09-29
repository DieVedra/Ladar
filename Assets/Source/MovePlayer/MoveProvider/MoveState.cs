using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveState
{
    private readonly StateSwitch _stateSwitch;
    private IMoveState _moveState;

    public MoveState(StateSwitch stateSwitch)
    {
        _stateSwitch = stateSwitch;
        _stateSwitch.OnStateChange += SetState;
    }
    public void Update()
    {
        _moveState?.Update();
        Debug.Log(_moveState);
    }
    private void SetState(IMoveState moveState)
    {
        _moveState = moveState;
    }
}
