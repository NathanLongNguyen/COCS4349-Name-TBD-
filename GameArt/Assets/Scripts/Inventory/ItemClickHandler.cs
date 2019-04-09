using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;

    /*private InventoryItemBase AttachedItem
    {
        get
        {
            ItemClickHelper itemClick = gameObject.transform.Find("ItemImage").GetComponent<ItemClickHelper>();

            return itemClick.Item;
        }
    }
    public void OnItemClicked()
    {
        InventoryItemBase item = AttachedItem;

        if (item != null)
        {
            _Inventory.UseItem(item);
        }
    }*/
}
