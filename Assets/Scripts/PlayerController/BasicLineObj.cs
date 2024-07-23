using UnityEngine;

public class BasicLineObj : MonoBehaviour
{
    [SerializeField] private PlayerLineChanger _playerLineChanger;
    [SerializeField] private PlayerLineController _playerLineController;
    [SerializeField] private int _lineNumber = 0;

    private void Awake()
    {
        _playerLineController.lines[_lineNumber] = new BasicLine(transform.position.x, _playerLineChanger).Execute;
    }
}