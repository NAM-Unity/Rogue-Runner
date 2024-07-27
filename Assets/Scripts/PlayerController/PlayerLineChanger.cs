using UnityEngine;

public class PlayerLineChanger : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Rigidbody2D _rb;

    private float _destention, _start, _progress;
    private bool _isMoving = false;

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        _progress += Time.fixedDeltaTime * _speed;
        if (_progress >= 1) {
            _progress = 1;
            _isMoving = false;
        }

        var dest = Mathf.SmoothStep(_start, _destention, _progress);

        _rb.MovePosition(new Vector2(dest, transform.position.y));
    }

    public void ChangeLine(float destention)
    {
        _destention = destention;
        _start = transform.position.x;
        _isMoving = true;
        _progress = 0;
    }
}