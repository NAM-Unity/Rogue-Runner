using System;

public interface IInput
{
    public event Action<int> SideSwipe;
    public event Action UpSwipe, DownSwipe;
}
