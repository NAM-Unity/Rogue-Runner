using System.Collections;
using UnityEngine;

[RequireComponent(typeof(KinematicMoveController))]
public class InfiniteVerticalMove : MonoBehaviour
{
    public float speed, acceleration;
    private KinematicMoveController _move;

    private void Awake()
    {
        _move = GetComponent<KinematicMoveController>();
    }

    private void FixedUpdate()
    {
        _move.Move(speed * Time.fixedDeltaTime * Vector2.up);
        speed += acceleration * Time.fixedDeltaTime;
    }
}