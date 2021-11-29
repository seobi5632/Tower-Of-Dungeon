using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/Item")]
public class Items : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    [TextArea]
    public string itemDesc;

    public ItemType itemType;
    public float value;
    public int itemCount;
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        if (value != 0)
        {
            GameObject.Find("Player").GetComponent<CharacterStat>().RecoveryHP(value);
            Debug.Log("Using " + name);
            return;
        }
        Debug.Log("Using " + name);
        RemoveFromInventory();
    }

    public void RemoveFromInventory()
    {
        Inventorys.instace.Remove(this);
    }

    public enum ItemType
    {
        Equipment,
        Used
    }
}
