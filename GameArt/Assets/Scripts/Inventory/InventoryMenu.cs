using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool InInventory = false;

    public GameObject inventoryUI;
    public GameObject background;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowInventory();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            HideInventory();
        }
    }

    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void HideInventory()
    {
        inventoryUI.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1f;
    }
}
