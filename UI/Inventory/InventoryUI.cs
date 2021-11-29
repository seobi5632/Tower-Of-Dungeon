using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventorys inventory;

    InventorySlot[] slots;

    public InventorySlot[] GetSlots() { return slots; }
    void Start()
    {
        inventory = Inventorys.instace;
        inventory.OnItemChangedCallback += UpdateUI;
        
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.isPause == false)
        {
            if (Input.GetButtonDown("Inventory"))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
            if (inventoryUI.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    inventoryUI.SetActive(!inventoryUI.activeSelf);
                }
            }
        }
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Inventory.Count)
            {
                slots[i].AddItem(inventory.Inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }       
    }
}
