using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    Default,
    Consumable,
    Weapon
}

public class InteractableItemBase : MonoBehaviour
{
    public string Name;

    public Sprite Image;

    public EItemType ItemType;

}

public class InventoryEventArgs : EventArgs
{
    public InventoryItemBase Item;

    public InventoryEventArgs(InventoryItemBase item)
    {
        Item = item;
    }  
}

public class InventoryItemBase : InteractableItemBase
{
    public InventorySlot Slot
    {
        get; set;
    }

    //Use for when pick-up becomes usable weapon
    public virtual void OnUse()
    {
        //transform.localPosition = PickPosition;
        //transform.localEulerAngles = PickRotation;
    }

    public virtual void OnPickup()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.SetActive(false);

    }

    /* Use for when pick-up becomes usable weapon(?) 
    public Vector3 PickPosition;
    public Vector3 PickRotation;
    public bool UseItemAfterPickup = false;
    */
}

