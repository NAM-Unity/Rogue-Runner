using System;
using UnityEngine;

[RequireComponent(typeof(KinematicMoveController))]
public class PlayerLineChanger : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private KinematicMoveController _move;

    private float _destenation, _start, _progress;
    private bool _isMoving = false;

    private void Awake() {
        _move = GetComponent<KinematicMoveController>();
    }

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        if (_progress == 1) {
            _isMoving = false;
            return;
        }

        _progress += Time.fixedDeltaTime * _speed;
        _progress = Mathf.Clamp01(_progress);

        var destNextFrame = Mathf.SmoothStep(_start, _destenation, _progress);
        var shouldTravel = destNextFrame - _move.position.x;
        _move.Move(Vector2.right * shouldTravel);
    }

    public void ChangeLine(float destenation)
    {
        _destenation = destenation;
        _start = transform.position.x;
        _isMoving = true;
        _progress = 0;
    }
}