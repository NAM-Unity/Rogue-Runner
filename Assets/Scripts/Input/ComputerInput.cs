using System;
using UnityEngine;

public class ComputerInput : MonoBehaviour, IInput
{

    public event Action<int> SideSwipe;
    public event Action UpSwipe, DownSwipe;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) SideSwipe?.Invoke(-1);
        if (Input.GetKey(KeyCode.RightArrow)) SideSwipe?.Invoke(1);
        if (Input.GetKey(KeyCode.UpArrow)) UpSwipe?.Invoke();
        if (Input.GetKey(KeyCode.DownArrow)) DownSwipe?.Invoke();
    }
}