using UnityEngine;
using static UnityEditor.Progress;

public class SlotData
{
    [SerializeField] private bool _isFilled = false;
    [SerializeField] private ItemData _item = null;

    public bool IsFilled => _isFilled;
    public ItemData Item => _item;

    public void SetItem(ItemData newItem)
    {
        _item = newItem;
        _isFilled = true;
    }

    public void ClearItem()
    {
        _item = null;
        _isFilled = false;
    }
}
