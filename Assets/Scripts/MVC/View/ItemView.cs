using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _iconImage;

    public void UpdateDisplay(SlotData slotData)
    {
        bool hasFilled = slotData.IsFilled;
        _iconImage.enabled = hasFilled;

        if (hasFilled)
        {
            _iconImage.sprite = slotData.Item.ItemData.Icon;
        }
    }
} 