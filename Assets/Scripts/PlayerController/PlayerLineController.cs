

using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineController : MonoBehaviour
{

    [SerializeField] private IInput _input;
    [SerializeField] private int _line = 0;

    public readonly Dictionary<int, Action> _lines = new();

    private void Awake()
    {
        _input.SideSwipe += ChangeLine;
    }

    private void ChangeLine(int diff)
    {
        _line += diff;
        _lines[_line]();
    }
}