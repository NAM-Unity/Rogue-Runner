using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemData;

    void ApplyStatEffects(PlayerStats player)
    {
        foreach (var modifier in itemData.Modifiers)
        {
            if (modifier.IsAddition)
            {
                player.AddToStat(modifier.Stat, modifier.Value);
            }
            else
            {
                player.ChangeStats(modifier.Stat, modifier.Value);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null)
        {
            ApplyStatEffects(player);
            Destroy(gameObject);
        }
    }
}
