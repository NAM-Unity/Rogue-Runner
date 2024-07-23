using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_FirstAidKit : MonoBehaviour,Item
{
    int _healthToRestore = 50;
    public void ApplyStatEffects(PlayerStats player)
    {
        player.AddToStat("Health", _healthToRestore);
    }
}
