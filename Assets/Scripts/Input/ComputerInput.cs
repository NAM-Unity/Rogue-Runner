using System;
using UnityEngine;

public class ComputerInput : MonoBehaviour, IInput
{

    public event Action<int> SideSwipe;
    public event Action UpSwipe, DownSwipe;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) SideSwipe?.Invoke(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) SideSwipe?.Invoke(1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpSwipe?.Invoke();
        if (Input.GetKeyDown(KeyCode.DownArrow)) DownSwipe?.Invoke();
    }
}