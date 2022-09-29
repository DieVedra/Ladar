using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput
{
    private readonly Transform _transformBody;
    private StateSwitch _stateSwitch;
    private SetValue _setValue;
    private Vector3 _direction;
    public KeyboardInput(Transform transform, StateSwitch stateSwitch, SetValue setValue)
    {
        _transformBody = transform;
        _stateSwitch = stateSwitch;
        _setValue = setValue;
        _direction = Vector3.zero;
    }
    public void Update()
    {
        MoveCharacter();
        JumpCharacter();
        CheckSpeedMove();
    }
    private void MoveCharacter()
    {
        _direction = Vector3.zero;

        _direction = MoveCoordinates();

        _setValue.SetDirection(_direction);
        //if (_direction != Vector3.zero)
        //{
        //    _stateSwitch.SetWalkState();
        //}
    }
    private void CheckSpeedMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _setValue.SetSpeed(Speed.Low);
                _setValue.SetJumpHight(JumpHight.Small);
            }
            else
            {
                _setValue.SetSpeed(Speed.Fast);
                _setValue.SetJumpHight(JumpHight.Hight);
            }
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            _setValue.SetSpeed(Speed.Low);
            _setValue.SetJumpHight(JumpHight.Small);
        }
        else
        {
            _setValue.SetSpeed(Speed.Medium);
            _setValue.SetJumpHight(JumpHight.Medium);
        }
    }
    private void JumpCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_stateSwitch.SetJumpState();
            _stateSwitch.ToJump();
        }
    }
    private Vector3 MoveCoordinates()
    {
        return (Input.GetAxisRaw("Horizontal") * _transformBody.right + Input.GetAxisRaw("Vertical") * _transformBody.forward).normalized;
        //return Input.GetAxis("Horizontal") * _transformBody.right + Input.GetAxis("Vertical") * _transformBody.forward;
    }
}
