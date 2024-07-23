using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    string PlayerName;
    PlayerStats _playerStats;
    public abstract void Shoot();
    public abstract void Ability();
}
