using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput
{
    private Transform _head;
    private Transform _body;
    private float _mouseY;
    private float _mouseX;
    private float _upBoard = -165f;
    private float _downBoard = -30f;
    private float _xRotation = -90f;
    public MouseInput(Transform head, Transform body)
    {
        _head = head;
        _body = body;
    }
    public void Update(float sensivityMouse)
    {
        HeadRotate(_head,-sensivityMouse);
        BodyRotate(_body, sensivityMouse);
    }
    private void HeadRotate(Transform rotated, float sensivityMouse)
    {
        _mouseY = Input.GetAxis("Mouse Y") * (sensivityMouse * 0.5f) *  Time.deltaTime;
        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _upBoard, _downBoard);
        rotated.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
    private void BodyRotate(Transform rotated, float sensivityMouse)
    {
        _mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime;
        rotated.Rotate(_mouseX * new Vector3(0f, 1f, 0f));
    }
}
