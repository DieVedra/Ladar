using TMPro;
using UnityEditor;
using UnityEngine;

public class SetValue
{
    private Jump _jump;
    private Walk _walk;
    private Idle _idle;
    private TMP_Text _textSpeed;
    public SetValue(Jump jump, Walk walk, Idle idle, TMP_Text textSpeed)
    {
        _jump = jump;
        _walk = walk;
        _idle = idle;
        _textSpeed = textSpeed;
    }
    public void SetDirection(Vector3 direction)
    {
        _walk.SetDirection(direction);
        _jump.SetDirection(direction);
        _idle.SetDirection(direction);
    }
    public void SetSpeed(Speed speed)
    {
        _walk.SetSpeed(speed);
        _jump.SetSpeed(speed);

        _textSpeed.text = $"Speed: {(float)speed}";
    }
    public void SetJumpHight(JumpHight jumpHight)
    {
        _jump.SetJumpHight(jumpHight);
    }
}