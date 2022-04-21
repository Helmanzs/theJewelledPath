using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHolder : MonoBehaviour
{
    private float damage = 0;
    private float range = 0;
    private float attackSpeed = 0;
    private Color color = Color.white;
    private List<Tuple<Effect, float>> effects = new List<Tuple<Effect, float>>();

    public float fireMulti = 0;
    public float iceMulti = 0;
    public float poisonMulti = 0;
    public float lightningMulti = 0;
    public float vulnerabilityMulti = 0;
    public float manaMulti = 0;

    private Renderer rend = null;

    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    public float Range
    {
        get => range;
        private set
        {
            range = 2;
            if (value >= 2 && value <= 10)
            {
                range = value;
            }
            else
            {
                range = 10;
            }
        }
    }
    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }
    public List<Tuple<Effect, float>> Effects
    {
        get => effects;
        private set => effects = value;
    }


    public Color Color
    {
        get => color;
        set
        {
            if (rend == null) rend = GetComponent<Renderer>();
            color = (color + value) * .5f;
            rend.material.color = color;
        }
    }

    public void AddGem(Gem gem, float initMulti)
    {
        this.Damage += gem.damage;
        this.Range += gem.range;
        this.AttackSpeed += gem.attackSpeed;
        this.Color = gem.Color;
        AddEffect(gem.Effect, initMulti);
    }

    public void AddAmplfierEffect(List<Tuple<Effect, float>> effects)
    {
        foreach (Tuple<Effect, float> effect in effects)
        {

            if (effect.Item1 is FireEffect)
                fireMulti += effect.Item2;
            if (effect.Item1 is IceEffect)
                iceMulti += effect.Item2;
            if (effect.Item1 is LightningEffect)
                lightningMulti += effect.Item2;
            if (effect.Item1 is PoisonEffect)
                poisonMulti += effect.Item2;
            if (effect.Item1 is ManaStealEffect)
                manaMulti += effect.Item2;
            if (effect.Item1 is CritEffect)
                vulnerabilityMulti += effect.Item2;
        }
    }

    public void RemoveAmplfierEffect(List<Tuple<Effect, float>> effects)
    {
        foreach (Tuple<Effect, float> effect in effects)
        {
            if (effect.Item1 is FireEffect)
                fireMulti -= effect.Item2;
            if (effect.Item1 is IceEffect)
                iceMulti -= effect.Item2;
            if (effect.Item1 is LightningEffect)
                lightningMulti -= effect.Item2;
            if (effect.Item1 is PoisonEffect)
                poisonMulti -= effect.Item2;
            if (effect.Item1 is ManaStealEffect)
                manaMulti -= effect.Item2;
            if (effect.Item1 is CritEffect)
                vulnerabilityMulti -= effect.Item2;
        }
    }

    public void SumEffects(Effect effect, ref float value)
    {
        if (effect is FireEffect)
            value += fireMulti;
        else if (effect is IceEffect)
            value += iceMulti;
        else if (effect is LightningEffect)
            value += lightningMulti;
        else if (effect is PoisonEffect)
            value += poisonMulti;
        else if (effect is ManaStealEffect)
            value += manaMulti;
        else if (effect is CritEffect)
            value += vulnerabilityMulti;
    }

    public void ClearAmplifierEffects()
    {
        fireMulti = 0;
        iceMulti = 0;
        poisonMulti = 0;
        lightningMulti = 0;
        vulnerabilityMulti = 0;
        manaMulti = 0;
    }
    private void AddEffect(Effect effect, float initMulti)
    {
        if (effects.Count == 0)
        {
            Tuple<Effect, float> temp = new Tuple<Effect, float>(effect, initMulti);
            effects.Add(temp);
            return;
        }

        for (int i = Effects.Count - 1; i >= 0; i--)
        {
            if (Effects[i].Item1.GetType() == effect.GetType())
            {
                Effects[i] = Tuple.Create(Effects[i].Item1, (float)Math.Round(Effects[i].Item2 + 0.05f, 2));
                return;
            }
        }

        Effects.Add(Tuple.Create(effect, initMulti));
        RecalculateEffects(Effects, initMulti);
    }
    private void RecalculateEffects(List<Tuple<Effect, float>> effects, float initMulti)
    {
        int differentElementCount = effects.Count;
        float addition;
        float multiplier;
        for (int i = effects.Count - 1; i >= 0; i--)
        {
            addition = (effects[i].Item2 - initMulti < 0) ? 0 : effects[i].Item2 - initMulti;
            multiplier = (float)Math.Round(effects[i].Item2 - differentElementCount * 0.05f, 2);
            multiplier = (multiplier <= 0) ? 0.01f : multiplier;
            effects[i] = Tuple.Create(effects[i].Item1, multiplier + addition);
        }
    }

    public void Clear()
    {
        Damage = 0;
        Range = 0;
        AttackSpeed = 0;
        Color = Color.white;
        Effects.Clear();
    }

    public void DisplayEffects()
    {
        Effects.ForEach(effect => Debug.Log($"{effect.Item1} - {effect.Item2}"));
    }
}
