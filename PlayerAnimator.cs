using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponAninationDict;

    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        weaponAninationDict = new Dictionary<Equipment, AnimationClip[]>();

        foreach(WeaponAnimations a in weaponAnimations)
        {
            weaponAninationDict.Add(a.weapon, a.clips);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem.equipSlot == EquipmentSlot.Weapon)
        {
            if (weaponAninationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAninationDict[newItem];
            }
        }
        else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Weapon)
        {
            currentAttackAnimSet = defaultAttackAnimSet;
        }
        if (newItem != null && newItem.equipSlot == EquipmentSlot.Sheild)
        {

        }
        else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Sheild)
        {

        }
    }

    [System.Serializable]
    public struct WeaponAnimations
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
