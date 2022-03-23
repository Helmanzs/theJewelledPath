using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHolder : MonoBehaviour
{
    private float damage = 0;
    private float range = 0;
    private float attackSpeed = 0;
    private Color color;
    private List<EffectDataHolder> effects = new List<EffectDataHolder>();

    public float Damage
    {
        get => damage;
        private set => damage = value;
    }
    public float Range
    {
        get => range;
        private set => range = value;
    }
    public float AttackSpeed
    {
        get => attackSpeed;
        private set => attackSpeed = value;
    }
    public List<EffectDataHolder> Effects
    {
        get => effects;
        private set => effects = value;
    }
    public Color Color
    {
        get => color;
        set
        {
            color = (color + value) * .5f; ;
        }
    }

    public void AddGem(Gem gem)
    {
        this.Damage += gem.damage;
        this.Range += gem.range;
        this.AttackSpeed += gem.attackSpeed;
        AddEffect(gem.Effect);
    }

    private void AddEffect(Effect effect)
    {
        for (int i = Effects.Count; i > 0; i--)
        {
            if (Effects[i].Effect == effect)
            {
                EffectDataHolder data = Effects[i];
                data.EffectMultiplier += 0.05f;
                Effects[i] = data;
            }
            else
            {
                Effects.Add(new EffectDataHolder(effect, 0f));
                RecalculateEffects(Effects);
            }
        }
    }

    private void RecalculateEffects(List<EffectDataHolder> effects)
    {
        int differentElementCount = effects.Count;
        float addition = 0;
        for (int i = Effects.Count; i > 0; i--)
        {
            EffectDataHolder data = Effects[i];
            addition = data.EffectMultiplier - 0.35f;
            if (data.EffectMultiplier == 0f)
            {
                data.EffectMultiplier = 0.35f - differentElementCount * 0.05f;
            }
            else
            {
                data.EffectMultiplier = 0.35f - differentElementCount * 0.05f + addition;
            }
            effects[i] = data;
        }
    }
}
