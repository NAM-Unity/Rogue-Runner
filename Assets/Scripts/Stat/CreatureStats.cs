using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureStats : MonoBehaviour
{
    public Dictionary<StatType, StatHandler> _stats;

    void Start()
    {
        _stats = new Dictionary<StatType, StatHandler>()
        {
            { StatType.Health, new HealthStatHandler(100f) },
            { StatType.MaxHealth, new SimpleStatHandler() { Value = 100f } },
            { StatType.ArmorPercentage, new PercentageStatHandler() },
        };
    }

    public void ChangeStats(StatType statType, float statValue)
    {
        if (_stats.ContainsKey(statType))
        {
            if (statType == StatType.MaxHealth && _stats[StatType.Health] is HealthStatHandler healthHandler)
            {
                healthHandler.MaxHealth = statValue;
            }
            _stats[statType].Value = statValue;
            Debug.Log($"{statType} set to {_stats[statType].Value}");
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
            if (statType == StatType.MaxHealth && _stats[StatType.Health] is HealthStatHandler healthHandler)
            {
                healthHandler.MaxHealth = _stats[statType].Value;
            }
            _stats[statType].Value += valueToAdd;
            Debug.Log($"{statType} increased by {valueToAdd} to {_stats[statType].Value}");
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
            return _stats[statType].Value;
        }
        else
        {
            Debug.LogWarning($"Stat {statType} not found!");
            return 0f;
        }
    }

    public Dictionary<StatType, float> GetAllStats()
    {
        Dictionary<StatType, float> allStats = new Dictionary<StatType, float>();
        foreach (var stat in _stats)
        {
            allStats[stat.Key] = stat.Value.Value;
        }
        return allStats;
    }
}
