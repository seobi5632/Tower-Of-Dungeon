using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipmet", menuName = "Inventory/Equipmet")]
public class Equipment : Items
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public float armorModifier;
    public float damageModifier;
    public float criticalModifier;
    public float criticalperModifier;
    public float rangeModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Feet, Sheild }