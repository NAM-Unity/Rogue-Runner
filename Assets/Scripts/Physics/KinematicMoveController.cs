using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KinematicMoveController : MonoBehaviour {
    private Rigidbody2D _rb;
    private Vector2 _moveAmount;

    public Vector2 position => _rb.position;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }

    private void FixedUpdate() {
        _rb.MovePosition(_rb.position + _moveAmount);
        _moveAmount = Vector2.zero;
    }

    public void Move(Vector2 amount) {
        _moveAmount += amount;
    }
}