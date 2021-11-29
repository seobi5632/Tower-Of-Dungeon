using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    public bool isPickUp = false;

    RaycastHit hit;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Text actionText;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        CheckItem();
        TryAction();
    }

    void TryAction()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckItem();
            CanPickUp();
        }
    }

    void CanPickUp()
    {
        if(isPickUp)
        {
            if(hit.transform != null)
            {
                Destroy(hit.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
    void CheckItem()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            if(hit.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
            else
            {
                ItemInfoDisappear();
            }
        }
    }
    void ItemInfoAppear()
    {
        isPickUp = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hit.transform.GetComponent<ItemPickUps>().item.name + " 획득 " + "<color=yellow>" + " CLICK " + "</color>";
        
    }
    void ItemInfoDisappear()
    {
        isPickUp = false;
        actionText.gameObject.SetActive(false);
    }
}
