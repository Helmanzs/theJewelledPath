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
    private Renderer rend = null;

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
    public void AddGem(GemHolder gem, float initMulti)
    {
        this.Damage += gem.damage;
        this.Range += gem.range;
        this.AttackSpeed += gem.attackSpeed;
        SumEffects(gem.effects);
    }
    public void RemoveGem(GemHolder gem, float initMulti)
    {
        this.Damage -= gem.damage;
        this.Range -= gem.range;
        this.AttackSpeed -= gem.attackSpeed;
        DifferEffects(gem.effects);

    }

    private void DifferEffects(List<Tuple<Effect, float>> ampEffects)
    {
        for (int i = Effects.Count - 1; i >= 0; i--)
        {
            Tuple<Effect, float> effect = Effects[i];
            Tuple<Effect, float> ampEffect = ampEffects.Find(eff => eff.GetType() == effect.GetType());
            if (effect != null)
            {
                Effects[i] = Tuple.Create(effect.Item1, effect.Item2 - ampEffect.Item2);
                ampEffects.Remove(ampEffect);
            }
        }
    }

    private void SumEffects(List<Tuple<Effect, float>> ampEffects)
    {
        if (Effects.Count == 0)
        {
            ampEffects.ForEach(ampEffect => effects.Add(ampEffect));
            return;
        }


        for (int i = Effects.Count - 1; i >= 0; i--)
        {
            Tuple<Effect, float> effect = Effects[i];
            Tuple<Effect, float> ampEffect = ampEffects.Find(eff => eff.GetType() == effect.GetType());
            if (effect != null)
            {
                Effects[i] = Tuple.Create(effect.Item1, effect.Item2 + ampEffect.Item2);
                ampEffects.Remove(ampEffect);
            }
        }
        ampEffects.ForEach(ampEffect => effects.Add(ampEffect));

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

        Effects.Add(Tuple.Create(effect, 0.35f));
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
}
