using UnityEngine;

public class PlayerLineChanger : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rb;

    private int _destention = 0;
    private bool _isMoving = false;

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        var distanceVector = transform.position.x - _destention;
        var distance = Mathf.Abs(distanceVector);
        var moveAmount = _speed * Time.fixedDeltaTime;

        if (distance < _speed * moveAmount)
        {
            _isMoving = false;
            moveAmount = distance;
        }

        _rb.MovePosition(_rb.position + Mathf.Sign(distanceVector) * moveAmount * Vector2.right);
    }

    public void ChangeLine(int destention)
    {
        _destention = destention;
        _isMoving = true;
    }
}