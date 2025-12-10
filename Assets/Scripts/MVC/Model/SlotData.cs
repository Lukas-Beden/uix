using UnityEngine;

public class SlotData : MonoBehaviour
{
    [SerializeField] private bool _isFilled = false;
    [SerializeField] private ItemData _item = null;

    public ItemData GetItem()
    {
        return _item;
    }

    public void SetItem(ItemData item)
    {
        _item = item;
    }

    public bool GetIsFilled()
    {
        return _isFilled;
    }

    public void SetIsFilled(bool isFilled)
    {
        _isFilled = isFilled;
    }
}
