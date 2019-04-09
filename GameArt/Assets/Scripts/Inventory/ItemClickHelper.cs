using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClickHelper : MonoBehaviour
{
    public InventoryItemBase Item { get; set; }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
}
