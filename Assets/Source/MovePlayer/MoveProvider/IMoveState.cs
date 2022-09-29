using UnityEditor;
using UnityEngine;

public interface IMoveState
{
    public void Update();
    public void Start();
    public void Stop();
}