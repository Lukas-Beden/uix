using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ItemController : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ItemModel _model;
    [SerializeField] private ItemView _view;
    [SerializeField] private InventoryController _inventoryController;

    private Transform _originalParent;
    private Vector3 _originalPosition;

    private bool _isDragging;

    public void Start()
    {
        _inventoryController = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isDragging)
        {
            Debug.Log("Pointer Click");
            var itemModel = GetComponent<ItemModel>();
            _inventoryController.RemoveItem(itemModel);
            Destroy(gameObject);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        _isDragging = true;

        _originalParent = transform.parent;
        _originalPosition = transform.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        _isDragging = false;

        GameObject closestSlot = null;
        float minDistance = 20f;

        foreach (var slot in _inventoryController.Model.Slots)
        {
            float distance = Vector3.Distance(transform.position, slot.Key.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestSlot = slot.Key;
            }
        }

        if (closestSlot != null)
        {
            if (!_inventoryController.Model.Slots[closestSlot].IsFilled)
            {
                _inventoryController.Model.Slots[_originalParent.gameObject].ClearItem();
                transform.SetParent(closestSlot.transform);
                transform.localPosition = Vector3.zero;
                _inventoryController.Model.Slots[closestSlot].SetItem(_model);
            }
            else
            {
                ItemModel selectedItem = _model;
                ItemModel otherItem = _inventoryController.Model.Slots[closestSlot].Item;

                transform.SetParent(closestSlot.transform);
                transform.localPosition = Vector3.zero;

                otherItem.gameObject.transform.SetParent(_originalParent);
                otherItem.gameObject.transform.localPosition = Vector3.zero;

                _inventoryController.Model.Slots[closestSlot].SetItem(selectedItem);
                _inventoryController.Model.Slots[_originalParent.gameObject].SetItem(otherItem);
            }
        } else
        {
            transform.SetParent(_originalParent);
            transform.localPosition = Vector3.zero;
        }
    }
}