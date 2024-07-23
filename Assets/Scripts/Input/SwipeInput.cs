using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour, IInput
{
    private Vector2 _fingerDownPosition;
    private Vector2 _fingerUpPosition;

    [SerializeField]
    private float _minDistanceForSwipe = 20f;

    public event Action<int> SideSwipe;
    public event Action UpSwipe;
    public event Action DownSwipe;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _fingerUpPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (!SwipeDistanceChec()) return;
        
        Vector2 direction = _fingerUpPosition - _fingerDownPosition;

        if (Math.Abs(direction.y) > Math.Abs(direction.x))
        {
            if (direction.y > 0)
                UpSwipe?.Invoke();
            else
                DownSwipe?.Invoke();
        }
        else
        {
            SideSwipe?.Invoke(direction.x > 0 ? 1 : -1);
        }

    }

    private bool SwipeDistanceChec()
    {
        return Vector2.Distance(_fingerDownPosition, _fingerUpPosition) > _minDistanceForSwipe;
    }
}