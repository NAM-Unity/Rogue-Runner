using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    public string ScriptName;
    public float ProbabilityPercentage;
    public Sprite ItemSprite;
}