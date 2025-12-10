using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Transform _slotContainer;

    private List<SlotView> _slotViews = new List<SlotView>();

    public void CreateSlotViews(int count)
    {
        foreach (SlotView slot in _slotViews)
        {
            Destroy(slot.gameObject);
        }
        _slotViews.Clear();

        for (int i = 0; i < count; i++)
        {
            GameObject slotObj = Instantiate(_slotPrefab, _slotContainer);
            SlotView slotView = slotObj.GetComponent<SlotView>();
            slotView.SetSlotIndex(i);
            _slotViews.Add(slotView);
        }
    }

    public void UpdateAllSlots(List<SlotData> slotsData)
    {
        for (int i = 0; i < slotsData.Count; i++)
        {
            if (i < _slotViews.Count)
            {
                _slotViews[i].UpdateDisplay(slotsData[i]);
            }
        }
    }

    public void SubscribeToSlotClicks(System.Action<int> callback)
    {
        foreach (SlotView slotView in _slotViews)
        {
            slotView.OnSlotClicked += callback;
        }
    }

    public void UnsubscribeFromSlotClicks(System.Action<int> callback)
    {
        foreach (SlotView slotView in _slotViews)
        {
            slotView.OnSlotClicked -= callback;
        }
    }
}
