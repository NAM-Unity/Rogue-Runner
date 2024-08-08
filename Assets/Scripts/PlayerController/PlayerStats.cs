using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerStats : CreatureStats
{
    void Start()
    {
        _stats = new Dictionary<StatType, StatHandler>()
        {
            { StatType.Health, new HealthStatHandler(100f) },
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

}
