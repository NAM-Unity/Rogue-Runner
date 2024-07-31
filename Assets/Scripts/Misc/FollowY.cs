using UnityEngine;

public class FollowY : MonoBehaviour {
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed, _offset;

    private void LateUpdate() {
        var newPos = transform.position;
        newPos.y = Mathf.Lerp(newPos.y, _target.position.y + _offset, _speed * Time.deltaTime);
        transform.position = newPos;
    }
}