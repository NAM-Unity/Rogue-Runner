using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CreatureStats
{
    void Start()
    {
        _stats = new Dictionary<StatType, float>()
        {
            { StatType.Health, 100f },
            { StatType.MaxHealth, 100f },
            { StatType.ArmorPercentage, 0f },
            { StatType.ReflectionPercentage, 0f },
            { StatType.AbilityCooldown, 0f },
            { StatType.Dmg, 10f },
            { StatType.Firedmg, 0f },
            { StatType.Electrodmg, 0f },
            { StatType.Bleedingdmg, 0f },
            { StatType.Naturedmg, 0f },
            { StatType.Confusiondmg, 0f },
            { StatType.EffectsDuration, 0f }
        };
    }

}
