using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsHUD : MonoBehaviour
{
    Dictionary<string, TMP_Text> items = new Dictionary<string, TMP_Text>();
    [SerializeField]
    Transform content;
    [SerializeField]
    GameObject ItemHUDprefab;
    public void PickedUp(ItemSO itemSO)
    {
        if (!itemSO.Temporary)
        if (items.ContainsKey(itemSO.ItemName))
        {
            string text = items[itemSO.ItemName].text;
            items[itemSO.ItemName].text = (int.Parse(text)+1).ToString();
        }
        else
        {
            GameObject go = Instantiate(ItemHUDprefab, content);
            go.GetComponent<Image>().sprite = itemSO.ItemSprite;
            items.Add(itemSO.name, go.GetComponentInChildren<TMP_Text>());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
