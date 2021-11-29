using UnityEngine;

public class ItemPickup : Interactable
{
    public Items item;

   
    public override void Interact()
    {
        base.Interact();
        
        PickUp();
    }

    void PickUp()
    {
        //Debug.Log("Pick Item." + item.name);
        bool wasPickUp = Inventorys.instace.Add(item);
        if (wasPickUp)  Destroy(gameObject);
        //Inventory.instace.AcquireItem(item);
        //if (isPickUp) Destroy(gameObject);
    }
}
