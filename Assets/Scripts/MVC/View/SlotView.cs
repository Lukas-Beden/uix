using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] private Image _iconImage;   
    [SerializeField] private Sprite _emptyIcon;   

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
}
