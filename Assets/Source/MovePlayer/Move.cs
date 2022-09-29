using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;
    [SerializeField] private float _sensivityMouse = 200f;
    [SerializeField] private LayerMask _floor;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private TMP_Text _textSpeed;
    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    private MoveState _moveState;
    private KeyboardInput _keyboardInput;
    private MouseInput _mouseInput;
    private Jump _jump;
    private Walk _walk;
    private Idle _idle;
    private StateSwitch _stateSwitch;
    private SetValue _setValue;
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
        _walk = new Walk(_characterController);
        _jump = new Jump(_characterController, _jumpCurve);
        _idle = new Idle(_characterController);
        _stateSwitch = new StateSwitch(_jump, _walk, _idle);
        _moveState = new MoveState(_stateSwitch);
        _setValue = new SetValue(_jump, _walk, _idle, _textSpeed);

        _keyboardInput = new KeyboardInput(_body, _stateSwitch, _setValue);
        _mouseInput = new MouseInput(_head, _body);
        _stateSwitch.SetIdleState();

    }
    private void Update()
    {
        _mouseInput.Update(_sensivityMouse);
        _keyboardInput.Update();
    }
    private void FixedUpdate()
    {
        _moveState.Update();
    }
}
public enum Speed
{
    Low = 4,
    Medium = 7,
    Fast = 12
}
public enum JumpHight
{
    Small = 2,
    Medium = 4, 
    Hight = 6
}
