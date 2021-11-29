using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject Arrow;

    Vector3 Target;


    void Start()
    {
        Target = PlayerManager.instance.player.transform.forward;
    }

    void Update()
    {
        transform.Translate(Target * Time.deltaTime * 5.0f);
    }
}
