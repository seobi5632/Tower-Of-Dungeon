using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public string transferMapName;
    public float detectRadius = 3f;
    public GameObject potal;
    Transform target;
    PlayerManager player;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        player = PlayerManager.instance;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (player.isFinish)
        {
            Debug.Log(player.isFinish);
            potal.SetActive(true);
            if (distance <= detectRadius)
            {
                SceneLoader.LoadSceneHandle(transferMapName, 3);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 center = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, detectRadius);
    }
}
