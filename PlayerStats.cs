using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
            critical_chance.AddModifier(newItem.criticalModifier);
            critical_per.AddModifier(newItem.criticalperModifier);
            range.AddModifier(newItem.rangeModifier);
            print(newItem.rangeModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            critical_chance.RemoveModifier(oldItem.criticalModifier);
            critical_per.RemoveModifier(oldItem.criticalperModifier);
            range.RemoveModifier(oldItem.rangeModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
