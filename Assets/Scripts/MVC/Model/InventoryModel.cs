using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    [SerializeField] private int _maxSlots = 3;
    private List<SlotData> _slots = new List<SlotData>();

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
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int slotIndex)
    {
        _slots[slotIndex].ClearItem();
    }

    public void AddSlot()
    {
        _slots.Add(new SlotData());
    }

    public void RemoveSlot()
    {
        foreach (SlotData slot in _slots)
        {
            if (!slot.IsFilled)
            {
                _slots.Remove(slot);
                return;
            }
        }
    }
}
