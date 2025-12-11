using UnityEngine;

public class ItemModel : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    public ItemData ItemData => _itemData;

    public ItemModel (ItemData itemData)
    {
        _itemData = itemData;
    }
}