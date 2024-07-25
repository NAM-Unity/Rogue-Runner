using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    public float ProbabilityPercentage;
    public Sprite ItemSprite;

    [System.Serializable]
    public class StatModifier
    {
        public StatType Stat;
        public float Value;
        public bool IsAddition; // true for add, false for change
    }

    public StatModifier[] Modifiers;
}
