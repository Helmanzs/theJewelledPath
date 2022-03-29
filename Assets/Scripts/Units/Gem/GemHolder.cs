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
    public bool IsEmpty => effects.Count == 0;
    public void AddGem(Gem gem)
    {
        this.Damage += gem.damage;
        this.Range += gem.range;
        this.AttackSpeed += gem.attackSpeed;
        this.Color = gem.Color;
        AddEffect(gem.Effect);
    }

    private void AddEffect(Effect effect)
    {
        if (effects.Count == 0)
        {
            Tuple<Effect, float> temp = new Tuple<Effect, float>(effect, 0.35f);
            effects.Add(temp);
            return;
        }

        for (int i = Effects.Count - 1; i >= 0; i--)
        {
            if (Effects[i].Item1.GetType() == effect.GetType())
            {
                Effects[i] = Tuple.Create(Effects[i].Item1, Effects[i].Item2 + 0.05f);
                continue;
            }

            Effects.Add(Tuple.Create(effect, 0f));
            RecalculateEffects(Effects);
        }
    }


    private void RecalculateEffects(List<Tuple<Effect, float>> effects)
    {
        int differentElementCount = effects.Count;
        float addition;
        for (int i = effects.Count - 1; i >= 0; i--)
        {
            addition = effects[i].Item2 - 0.35f;
            if (effects[i].Item2 <= 0)
            {
                effects[i] = Tuple.Create(effects[i].Item1, 0.35f - differentElementCount * 0.05f);
                continue;
            }
            effects[i] = Tuple.Create(effects[i].Item1, 0.35f - differentElementCount * 0.05f + addition);
        }
    }

    public void DisplayEffects()
    {

        effects.ForEach(effect => Debug.Log($"Effect: {effect.Item1}, multiplier: {effect.Item2}"));
    }

}
