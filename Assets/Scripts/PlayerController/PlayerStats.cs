using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerStats : CreatureStats
{
    [SerializeField]
    List<ItemSO> itemSOs = new List<ItemSO>();
    [SerializeField]
    HUD hud;
    void Start()
    {
        _stats = new Dictionary<StatType, StatHandler>()
        {
            { StatType.Health, new HealthStatHandler(100f) },
            { StatType.MaxHealth, new SimpleStatHandler() { Value = 100f } },
            { StatType.RegenAmount, new SimpleStatHandler() },
            {StatType.RegenTime, new SimpleStatHandler() },
            { StatType.ArmorPercentage, new PercentageStatHandler() },
            { StatType.ReflectionPercentage, new PercentageStatHandler() },
            { StatType.AbilityCooldown, new SimpleStatHandler() },
            { StatType.Dmg, new SimpleStatHandler() },
            { StatType.Firedmg, new SimpleStatHandler() },
            { StatType.Electrodmg, new SimpleStatHandler() },
            { StatType.Bleedingdmg, new SimpleStatHandler() },
            { StatType.Naturedmg, new SimpleStatHandler() },
            { StatType.Confusiondmg, new SimpleStatHandler() },
            { StatType.EffectsDuration, new SimpleStatHandler() }
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            ItemSO itemPicked = other.GetComponent<Item_Stat>().PickedUp(this);
            hud.ItemPickedUp(itemPicked);
            if (!itemPicked.Temporary)
            {
                itemSOs.Add(itemPicked);
            }
        }
     
    }
}
