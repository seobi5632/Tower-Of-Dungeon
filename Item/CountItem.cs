using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountItem : MonoBehaviour
{
    #region Singleton
    public static CountItem instace;
    public Items item;
    public Text count;


    void Awake()
    {
        instace = this;
    }
    #endregion

    public void SetSlotCount(Items item)
    {
        count.text = item.itemCount.ToString();
        Debug.Log("count");
    }
}
