using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float Health, MaxHealth, ArmorPercentage, ReflectionPercentage, AbilityCooldown;
    public float Dmg, Firedmg, Electrodmg, Bleedingdmg, Naturedmg, Confusiondmg;
    public float EffectsDuration;
    private Dictionary<string, float> _stats;

    void Start()
    {
        _stats = new Dictionary<string, float>()
        {
            { "Health", Health },
            { "ArmorPercentage", ArmorPercentage },
            { "ReflectionPercentage", ReflectionPercentage },
            { "AbilityCooldown", AbilityCooldown},
            { "Dmg", Dmg },
            { "Firedmg", Firedmg },
            { "Electrodmg", Electrodmg },
            { "Bleedingdmg", Bleedingdmg },
            { "Naturedmg", Naturedmg },
            { "Confusiondmg", Confusiondmg },
            { "EffectsDuration", EffectsDuration }
        };
    }
    public void ChangeStats(string statName, float statValue)
    {
        if (_stats.ContainsKey(statName))
        {
            _stats[statName] = validateStat(statName, statValue);
            Debug.Log($"{statName} set to {statValue}");
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found!");
        }
    }

    public void AddToStat(string statName, float valueToAdd)
    {
        if (_stats.ContainsKey(statName))
        {
            _stats[statName] = validateStat(statName, _stats[statName] + valueToAdd);
            Debug.Log($"{statName} increased by {valueToAdd} to {_stats[statName]}");
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found!");
        }
    }
    private float validateStat(string statName, float statValue)
    {
        if (statName == "Health")
        {
            return Mathf.Clamp(statValue, 0, _stats["MaxHealth"]);
        }
        else if (statName == "ArmorPercentage" || statName == "ReflectionPercentage")
        {
            return Mathf.Clamp(statValue, 0, 1);
        }
        return statValue;
    }

    public float GetStat(string statName)
    {
        if (_stats.ContainsKey(statName))
        {
            return _stats[statName];
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found!");
            return 0f;
        }
    }

    public Dictionary<string, float> GetAllStats()
    {
        return new Dictionary<string, float>(_stats);
    }
}

