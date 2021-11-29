using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorys : MonoBehaviour
{

    #region Singleton
    public static Inventorys instace;

    void Awake()
    {
        if (instace != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instace = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public int space = 20;

    public List<Items> Inventory = new List<Items>();

    public bool Add(Items item)
    {
        if (!item.isDefaultItem)
        {
            if (Inventory.Count >= space)
            {
                Debug.Log("Not enough");
                return false;
            }

            if (Inventory.Count == 0)
            {
                Inventory.Add(item);
                item.itemCount = 1;
            }
            else
            {
                Checkitem(item);
            }

            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Items item)
    {
        Inventory.Remove(item);
        

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }

    public void Checkitem(Items item)
    {
        if (item.itemType == Items.ItemType.Used)
        {
            for (int i = 0; i < Inventory.Count && Inventory[i] != null; i++)
            {
                if (Inventory[i].name == item.name)
                {
                    item.itemCount++;
                    return;
                }
            }
            Inventory.Add(item);
            item.itemCount = 1;
            return;
        }
        else
        {
            Inventory.Add(item);
            return;
        }
    }
}
