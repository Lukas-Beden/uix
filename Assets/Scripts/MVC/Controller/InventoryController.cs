using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryModel _model;
    [SerializeField] private InventoryView _view;

    private void Start()
    {
        // Initialiser la vue avec le nombre de slots du modèle
        _view.CreateSlotViews(_model.MaxSlots);
        UpdateView();
    }

    public void AddItem(ItemData item)
    {
        if (_model.AddItem(item))
        {
            UpdateView();
        }
    }

    public void RemoveItem(int slotIndex)
    {
        _model.RemoveItem(slotIndex);
        UpdateView();
    }

    public void AddSlot()
    {
        _model.AddSlot();
        _view.CreateSlotViews(_model.Slots.Count);
        UpdateView();
    }

    public void RemoveSlot()
    {
        _model.RemoveSlot();
        _view.CreateSlotViews(_model.Slots.Count);
        UpdateView();
    }

    private void UpdateView()
    {
        _view.UpdateAllSlots(_model.Slots);
    }
}