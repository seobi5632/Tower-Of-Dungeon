using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgUI : MonoBehaviour
{
    public GameObject dmgPrefab;
    public Transform target;
    float visibleTime = 10f;

    float lastMadeVisibleTime;
    Transform ui;
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;

        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            if (c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(dmgPrefab, c.transform).transform;
                ui.gameObject.SetActive(false);
                break;
            }
        }
    }

    void LateUpdate()
    {
        if (ui != null)
        {
            ui.position = target.position;
            ui.forward = -cam.forward;

            if (Time.time - lastMadeVisibleTime > visibleTime)
            {
                ui.gameObject.SetActive(false);
            }
        }
    }
}
