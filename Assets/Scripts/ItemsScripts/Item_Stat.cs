using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Stat : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public ItemSO ItemData;
    void Start()
    {
        _spriteRenderer.sprite = ItemData.ItemSprite;
    }
    void ApplyStatEffects(PlayerStats player)
    {
        foreach (var modifier in ItemData.Modifiers)
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
