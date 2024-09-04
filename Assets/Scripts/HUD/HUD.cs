using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    ItemDescription ItemDescription;
    [SerializeField]
    ItemsHUD itemsHUD;
    public void ItemPickedUp(ItemSO itemSO)
    {

        itemsHUD.PickedUp(itemSO);
        ItemDescription.Play(itemSO);
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
