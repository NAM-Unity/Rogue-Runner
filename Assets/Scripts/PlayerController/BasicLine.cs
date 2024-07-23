using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BasicLine
{
    private readonly PlayerLineChanger _lineChanger;
    private readonly float _destenation;

    public BasicLine(float destenation, PlayerLineChanger lineChanger)
    {
        _destenation = destenation;
        _lineChanger = lineChanger;
    }

    public void Execute()
    {
        _lineChanger.ChangeLine(_destenation);
    }
}
