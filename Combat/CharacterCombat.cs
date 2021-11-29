using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStat))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    const float combatCooldown = 5f;
    float lastAttackTime;

    float damage;


    public float attackDelay = 3f;


    public bool InCombat { get; private set; }
    public event System.Action OnAttack;

    public bool isCritical = false;
    public int attackIndex;

    public CharacterStat myStats;
    public CharacterStat opponentStats;

    void Start()
    {
        myStats = GetComponent<CharacterStat>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (Time.time - lastAttackTime > combatCooldown)
        {
            InCombat = false;
        }
    }

    public void Attack(CharacterStat targetStats)
    {
        if (attackCooldown <= 0f)
        {
            Critiacal();
            opponentStats = targetStats;
            if (OnAttack != null) OnAttack();

            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }
    
    public void Critiacal()
    {
        int crt = Random.Range(0, 100);

        if (myStats.critical_chance.GetValue() > crt)
        {
            isCritical = true;
            damage = myStats.damage.GetValue() * myStats.critical_per.GetValue();
        }
        else
        {
            isCritical = false;
            damage = myStats.damage.GetValue();
        }
    }

    public void AttackHit_AnimationEvent()
    {
        opponentStats.TakeDamage(damage, isCritical);

        if (opponentStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
