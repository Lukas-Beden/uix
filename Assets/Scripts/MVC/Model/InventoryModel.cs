using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    [SerializeField] private int _maxSlots = 3;
    private List<SlotData> _slots = new List<SlotData>();

    public event Action OnInventoryChanged;

    public int MaxSlots => _maxSlots;
    public List<SlotData> Slots => _slots;

    private void Awake()
    {
        InitializeSlots();
    }

    private void InitializeSlots()
    {
        for (int i = 0; i < _maxSlots; i++)
        {
            _slots.Add(new SlotData());
        }
    }

    public bool AddItem(ItemData item)
    {
        foreach (SlotData slot in _slots)
        {
            if (!slot.IsFilled)
            {
                slot.SetItem(item);
                OnInventoryChanged?.Invoke();
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int slotIndex)
    {
        _slots[slotIndex].ClearItem();
        OnInventoryChanged?.Invoke();
    }

    public void AddSlot()
    {
        _slots.Add(new SlotData());
        OnInventoryChanged?.Invoke();
    }

    public void RemoveSlot()
    {
        foreach (SlotData slot in _slots)
        {
            if (!slot.IsFilled)
            {
                _slots.Remove(slot);
                OnInventoryChanged?.Invoke();
                return;
            }
        }
    }
}
