using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Transform _slotContainer;

    private List<SlotView> _slotViews = new List<SlotView>();

    public void CreateSlotViews(int count)
    {
        // Détruire les anciens slots
        foreach (SlotView slot in _slotViews)
        {
            Destroy(slot.gameObject);
        }
        _slotViews.Clear();

        // Créer les nouveaux
        for (int i = 0; i < count; i++)
        {
            GameObject slotObj = Instantiate(_slotPrefab, _slotContainer);
            SlotView slotView = slotObj.GetComponent<SlotView>();
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
}
