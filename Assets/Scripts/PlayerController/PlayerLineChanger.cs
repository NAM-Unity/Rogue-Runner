using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLineChanger : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Rigidbody2D _rb;

    private float _destention, _start, _progress;
    private bool _isMoving = false;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        if (_progress == 1) {
            _isMoving = false;
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            return;
        }

        _progress += Time.fixedDeltaTime * _speed;
        _progress = Mathf.Clamp01(_progress);

        var shouldBeCovered = Mathf.SmoothStep(_start, _destention, _progress);
        var velocity = shouldBeCovered - transform.position.x;

        _rb.velocity = new Vector2(velocity / Time.fixedDeltaTime, _rb.velocity.y);
    }

    public void ChangeLine(float destention)
    {
        _destention = destention;
        _start = transform.position.x;
        _isMoving = true;
        _progress = 0;
    }
}