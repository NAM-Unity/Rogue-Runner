using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _itemStats_prefab;
    public ItemSO[] ItemSOs;
    public Dictionary<string, ItemSO> ItemSOsByName;

    void Start()
    {
        start_getAllItemsStatSO();
    }

    void Update()
    {
        
    }
    public void SpawnItemByName(Vector3 coordinates, string itemName)
    {
        if (ItemSOsByName.TryGetValue(itemName, out ItemSO itemToSpawn))
        {
            GameObject item = Instantiate(_itemStats_prefab, coordinates, Quaternion.identity);
            item.GetComponent<Item_Stat>().ItemData = itemToSpawn;
        }
        else
        {
            Debug.LogWarning($"ItemSO with name {itemName} not found!");
        }
    }
    void SpawnItemWithProbability(Vector3 coordinates)
    {
        float totalProbability = 0;
        foreach (var itemSO in ItemSOs)
        {
            totalProbability += itemSO.ProbabilityPercentage;
        }

        float randomPoint = Random.value * totalProbability;

        foreach (var itemSO in ItemSOs)
        {
            if (randomPoint < itemSO.ProbabilityPercentage)
            {
                SpawnItemByName(coordinates, itemSO.name);
                return;
            }
            else
            {
                randomPoint -= itemSO.ProbabilityPercentage;
            }
        }
    }
    void start_getAllItemsStatSO()
    {
        ItemSOs = Resources.LoadAll<ItemSO>("");
        ItemSOsByName = new Dictionary<string, ItemSO>();

        foreach (var itemSO in ItemSOs)
        {
            ItemSOsByName[itemSO.name] = itemSO;
        }

        if (ItemSOs.Length == 0)
        {
            Debug.LogWarning("No ItemSO found in Resources folder.");
        }
    }
}
