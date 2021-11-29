using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgText : MonoBehaviour
{
    public TextMesh dmgText;

    void Start()
    {
        Destroy(gameObject, 1f);      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 1.2f);
    }

    public void DisplayDamage(float Dmg, bool isCritical)
    {
        if (isCritical)
        {
            dmgText.text = "<color=#ff0000>" + Dmg + "</color>";
        }
        else
        {
            dmgText.text = "<color=#ffffff>" + Dmg + "</color>";
        }

    }
}
