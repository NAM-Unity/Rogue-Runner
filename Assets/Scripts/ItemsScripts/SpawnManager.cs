using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _itemStats_prefab;
    public ItemSO[] ItemSOs;
    public Dictionary<string, ItemSO> ItemSOsByName;
    double[] lines = {-1.5, 0, 1.5};
    //Spawn in game coordinates
    [SerializeField]
    private Transform _playerTransform;
    private int _regularSpawnNow = 10;
    private int _regularSpawnInterval = 10;
    private int _specialSpawnNow = 100;
    private int _specialSpawn = 90;
    private int _specialSpawnInterval = 100;

    void Start()
    {
        start_getAllItemsStatSO();
        GetPlayer();
    }

    void Update()
    {
        RegularSpawn();
        SpecialSpawn();
    }
    private void GetPlayer()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void RegularSpawn()
    {
        if (_playerTransform.position.y > _regularSpawnNow)
        {
        _regularSpawnNow += _regularSpawnInterval;
        Vector3 spawnPosition = new Vector3(_playerTransform.position.x, _regularSpawnNow, _playerTransform.position.z);
        SpawnItemWithProbability(spawnPosition, true);
        
        }
    }
    private void SpecialSpawn()
    {

        if (_playerTransform.position.y > _specialSpawn)
        {
        
            for (int i=0; i<3; i++)
            {
                Vector3 spawnPosition = new Vector3((float)lines[i], _specialSpawnNow, _playerTransform.position.z);
                SpawnItemWithProbability(spawnPosition, false);
            }
                _specialSpawnNow += _specialSpawnInterval;
        _specialSpawn = _specialSpawnNow-10;
        }
    
    }
    public void SpawnItemByName(Vector3 coordinates, string itemName, bool randomLine)
    {
        if (ItemSOsByName.TryGetValue(itemName, out ItemSO itemToSpawn))
        {
            if (randomLine)
            {
                
                coordinates.x = (float)lines[Mathf.RoundToInt(Random.Range(0,2))];
            }
            GameObject item = Instantiate(_itemStats_prefab, coordinates, Quaternion.identity);
            item.GetComponent<Item_Stat>().ItemData = itemToSpawn;
        }
        else
        {
            Debug.LogWarning($"ItemSO with name {itemName} not found!");
        }
    }
    void SpawnItemWithProbability(Vector3 coordinates, bool randomLine)
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
                SpawnItemByName(coordinates, itemSO.ItemName, randomLine);
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
