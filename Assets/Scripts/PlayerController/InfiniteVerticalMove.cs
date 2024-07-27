using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InfiniteVerticalMove : MonoBehaviour {
    public float startSpeed, acceleration;
    private Rigidbody2D _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * startSpeed;
    }

    private void FixedUpdate() {
        var newVelocity = _rb.velocity;
        newVelocity.y += acceleration * Time.fixedDeltaTime;
        _rb.velocity = newVelocity;
    }
}