using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel _model;
    [SerializeField] private InventoryView _view;

    private void Start()
    {
        for (int i = 0; i < _model.MaxSlots; i++)
        {
            AddSlot();
        }
    }

    public void AddSlot()
    {
        GameObject slotObj = Instantiate(_model.SlotPrefab, _model.SlotContainer);
        _model.AddSlot(slotObj);
    }

    public void RemoveSlot()
    {
        GameObject slotToRemove = _model.RemoveSlot();
        if (slotToRemove)
        {
            Destroy(slotToRemove);
        }
    }

    public void AddItem(GameObject item)
    {
        ItemModel itemModel = item.GetComponent<ItemModel>();
        Transform slot = _model.AddItem(itemModel);
        if (slot != null)
        {
            Instantiate(item, slot);
        }
    }

    public void RemoveItem(GameObject item)
    {

    }
}