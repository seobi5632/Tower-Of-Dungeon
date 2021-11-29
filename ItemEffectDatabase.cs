using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName;
    [Tooltip("못쓰는거야")]
    public string[] part;
    public int[] num;
}
public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
    [SerializeField]
    private SlotToolTip theToolTip;

    public void ShowToolTip(Items _item, Vector3 _pos)
    {
        theToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theToolTip.HideToolTip();
    }
}
