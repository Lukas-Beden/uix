using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _iconImage;   
    [SerializeField] private Sprite _emptyIcon;

    public event Action<int> OnSlotClicked;
    private int _slotIndex;

    public void SetSlotIndex(int slotIndex)
    {
        _slotIndex = slotIndex;
    }

    public void UpdateDisplay(SlotData slotData)
    {
        if (slotData.IsFilled)
        {
            _iconImage.sprite = slotData.Item.Icon;
        } else
        {
            _iconImage.sprite = _emptyIcon;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotClicked?.Invoke(_slotIndex);
    }
}
