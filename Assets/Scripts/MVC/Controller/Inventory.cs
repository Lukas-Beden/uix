using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventorySlot;
    [SerializeField] private ItemData _cardData;
    [SerializeField] private List<GameObject> _inventory;
    [SerializeField] private List<ItemData> _items;
    [SerializeField] private Transform _slotContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSlot(GameObject inventorySlot)
    {
        GameObject newSlot = Instantiate(inventorySlot, _slotContainer);
        _inventory.Add(newSlot);
    }

    public void AddItem(ItemData cardData)
    {
        foreach (GameObject slot in _inventory)
        {
            SlotData slotData = slot.GetComponent<SlotData>();
            if (slotData == null)
            {
                slotData.SetIsFilled(true);
                slotData.SetItem(cardData);
                return;
            } 
        }
        Debug.Log("padplace");
    }
}
