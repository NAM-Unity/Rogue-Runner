

using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IInput))]
public class PlayerLineController : MonoBehaviour
{
    [SerializeField] private int _line = 0;

    public readonly Dictionary<int, Action> lines = new();

    private void Awake()
    {
        var _input = GetComponent<IInput>();
        _input.SideSwipe += ChangeLine;
    }

    private void ChangeLine(int diff)
    {
        var newLine = _line + diff;
        if (!lines.ContainsKey(newLine)) return;

        lines[newLine]();
        _line = newLine;
    }
}