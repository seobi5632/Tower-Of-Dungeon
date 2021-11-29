using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public Button removeButton;

    public Text text_Count;

    public GameObject go_CountImage;

    public Items item;


    public void AddItem(Items newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        if (item.itemType == Items.ItemType.Used)
        {
            go_CountImage.SetActive(true);
            text_Count.text = item.itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void SetSlotCount(int _count)
    {
        item.Use();
        item.itemCount += _count;
        text_Count.text = item.itemCount.ToString();

        if (item.itemCount <= 0)
        {
            ClearSlot();
        }
    }

    public void OnRemoveButton()
    {
        Inventorys.instace.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if (item.itemType == Items.ItemType.Used) SetSlotCount(-1);
            else item.Use();
        }
    }
}
