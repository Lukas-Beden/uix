using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemController : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ItemModel _model;
    [SerializeField] private ItemView _view;
    [SerializeField] private InventoryController _inventoryController;

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
    }
}