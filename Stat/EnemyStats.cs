using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStat
{
    [SerializeField]
    GameObject[] go_item;
    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
        int i = Random.Range(0, 10);
    
        ItemDrop(i);

    }

    void ItemDrop(int i)
    {
        if (go_item[0] != null)
        {
            if (i < 7)
            {
                Instantiate(go_item[0], this.transform.position, Quaternion.identity);
            }
        }
        if (go_item[1] != null)
        {
            if (i < 2)
            {
                Instantiate(go_item[1], this.transform.position, Quaternion.identity);
            }
        }
    }
}
