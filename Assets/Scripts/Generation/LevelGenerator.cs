using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _parts;
    [SerializeField] private Vector2 _current, _offset;

    [SerializeField] private int _keepLoaded = 3, _leaveAfter = 1;
    private readonly Queue<GameObject> _loadedParts = new();

    private static LevelGenerator _instance;
    public static LevelGenerator Instance => _instance;

    private void Awake() {
        _instance = this;
        for (var i = 0; i < _keepLoaded; i++) {
            SpawnPart(_current);
            _current += _offset;
        }
    }

    public void NextChunk() {
        if (_leaveAfter != 0) {
            _leaveAfter--;
            return;
        }

        Destroy(_loadedParts.Dequeue());
        SpawnPart(_current);
        _current += _offset;
    }


    private void SpawnPart(Vector2 position) {
        var partIndex = Random.Range(0, _parts.Length);
        var part = _parts[partIndex];

        var loaded = Instantiate(part, position, Quaternion.identity);
        _loadedParts.Enqueue(loaded);
    }
}
