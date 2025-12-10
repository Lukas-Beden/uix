using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel _model;
    [SerializeField] private InventoryView _view;

    private void Start()
    {
        _model.OnInventoryChanged += OnInventoryChanged;
        _view.CreateSlotViews(_model.MaxSlots);
        _view.SubscribeToSlotClicks(RemoveItemOnSlotClicked); 
        UpdateView();
    }

    private void OnDestroy()
    {
        _model.OnInventoryChanged -= OnInventoryChanged;
        _view.UnsubscribeFromSlotClicks(RemoveItemOnSlotClicked);
    }
    private void OnInventoryChanged()
    {
        UpdateView();
    }

    private void RemoveItemOnSlotClicked(int slotIndex)
    {
        _model.RemoveItem(slotIndex);
    }

    public void AddItem(ItemData item)
    {
        _model.AddItem(item);
    }

    public void RemoveItem(int slotIndex)
    {
        _model.RemoveItem(slotIndex);
    }

    public void AddSlot()
    {
        _view.UnsubscribeFromSlotClicks(RemoveItemOnSlotClicked);
        _model.AddSlot();
        _view.CreateSlotViews(_model.Slots.Count);
        _view.SubscribeToSlotClicks(RemoveItemOnSlotClicked);
    }

    public void RemoveSlot()
    {
        _view.UnsubscribeFromSlotClicks(RemoveItemOnSlotClicked);
        _model.RemoveSlot();
        _view.CreateSlotViews(_model.Slots.Count);
        _view.SubscribeToSlotClicks(RemoveItemOnSlotClicked);
    }

    private void UpdateView()
    {
        _view.UpdateAllSlots(_model.Slots);
    }
}