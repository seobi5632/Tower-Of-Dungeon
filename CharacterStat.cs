using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    public Stats damage;
    public Stats range;
    public Stats critical_chance;
    public Stats critical_per;
    public Stats armor;

    string sound = "Hurt";

    public event System.Action<float, float> OnHealthChanged;
    #region Singleton
    public static CharacterStat instance;

    void Awake()
    {
        instance = this;
        currentHealth = maxHealth;
    }
    #endregion

    public void TakeDamage(float damage, bool isCritical)
    {
        SoundManager.instance.PlaySE(sound);

        Transform cam = Camera.main.transform; ;
        Quaternion quaternion = cam.rotation;
        GameObject DmgTextClone = Instantiate(PlayerManager.instance.dmgText, transform.position, quaternion);
        GameObject EffectClone = Instantiate(PlayerManager.instance.effect, transform.position, Quaternion.identity);

        Destroy(EffectClone, 1.0f);

        damage -= armor.GetValue();     //damage
        damage = Mathf.Clamp(damage, 0, float.MaxValue);

        currentHealth -= damage;
        DmgTextClone.GetComponent<DmgText>().DisplayDamage(damage, isCritical);

        //Debug.Log(transform.name + " takes " + damage + " damage. ");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void RecoveryHP(float value)
    {
        if (currentHealth + value > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += value;
        }

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died. ");
    }
}
