using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Text texts;
    PlayerManager playerManager;
    public Image healthSlider;

    void Start()
    {
        playerManager = PlayerManager.instance;
    }

    void Update()
    {
       
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        float heathPercent = playerCombat.myStats.currentHealth / playerCombat.myStats.maxHealth;
        healthSlider.fillAmount = heathPercent;
        texts.text = playerCombat.myStats.currentHealth.ToString();
    }
}
