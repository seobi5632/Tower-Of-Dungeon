using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : CharacterAnimator
{
    public Patterns[] patternAnimations;
    Dictionary<float, AnimationClip[]> patternAnimationDict;

    protected override void Start()
    {
        base.Start();
        GetComponent<CharacterStat>().OnHealthChanged += OnPatternChanged;
        patternAnimationDict = new Dictionary<float, AnimationClip[]>();

        foreach (Patterns a in patternAnimations)
        {
            patternAnimationDict.Add(a.hpPercent, a.clips);
        }
    }

    void OnPatternChanged(float maxHealth, float currentHealth)
    {
        float heathPercent = currentHealth / maxHealth;
        if (heathPercent <= 0.5 && heathPercent > 0.25)
        {
            if (patternAnimationDict.ContainsKey(0.5f))
            {
                currentAttackAnimSet = patternAnimationDict[0.5f];
                GetComponent<CharacterStat>().damage.AddModifier(10);
            }
        }
        else if (heathPercent <= 0.25 && heathPercent > 0)
        {
            currentAttackAnimSet = defaultAttackAnimSet;
        }
    }

    [System.Serializable]
    public struct Patterns
    {
        public float hpPercent;
        public AnimationClip[] clips;
    }
}
