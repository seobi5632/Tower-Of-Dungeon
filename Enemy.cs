using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStat))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStat myStats;

    float range;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStat>();
        range = radius;
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        radius = range * playerCombat.myStats.range.GetValue();

        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
