using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureStats : MonoBehaviour
{
    public Dictionary<StatType, float> _stats;

    void Start()
    {
        // Choose stats for creature
        // _stats = new Dictionary<StatType, float>()
        // {
        //     { StatType.Health, 100f },
        //     { StatType.MaxHealth, 100f },
        //     { StatType.ArmorPercentage, 0f },
        // };
    }

    public float ValidateStat(StatType statType, float statValue)
    {
        if (statType == StatType.Health)
        {
            return Mathf.Clamp(statValue, 0, _stats[StatType.MaxHealth]);
        }
        else if (statType == StatType.ArmorPercentage || statType == StatType.ReflectionPercentage)
        {
            return Mathf.Clamp(statValue, 0, 1);
        }
        return statValue;
    }

    public void ChangeStats(StatType statType, float statValue)
    {
        if (_stats.ContainsKey(statType))
        {
            _stats[statType] = ValidateStat(statType, statValue);
            Debug.Log($"{statType} set to {_stats[statType]}");
        }
        else
        {
            Debug.LogWarning($"Stat {statType} not found!");
        }
    }

    public void AddToStat(StatType statType, float valueToAdd)
    {
        if (_stats.ContainsKey(statType))
        {
            _stats[statType] = ValidateStat(statType, _stats[statType] + valueToAdd);
            Debug.Log($"{statType} increased by {valueToAdd} to {_stats[statType]}");
        }
        else
        {
            Debug.LogWarning($"Stat {statType} not found!");
        }
    }

    public float GetStat(StatType statType)
    {
        if (_stats.ContainsKey(statType))
        {
            return _stats[statType];
        }
        else
        {
            Debug.LogWarning($"Stat {statType} not found!");
            return 0f;
        }
    }

    public Dictionary<StatType, float> GetAllStats()
    {
        return new Dictionary<StatType, float>(_stats);
    }
}
