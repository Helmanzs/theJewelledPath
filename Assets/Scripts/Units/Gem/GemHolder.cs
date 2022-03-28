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
            Tuple<Effect, float> temp = new Tuple<Effect, float>(effect, 0);
            effects.Add(temp);
        }



        /*EffectDataHolder holder = new EffectDataHolder(Instantiate(effect), 0f);

        if (effects.Count == 0)
        {
            holder.effectMultiplier = 0.35f;
            Effects.Add(holder);
            return;
        }

        for (int i = Effects.Count - 1; i > 0; i--)
        {
            if (Effects[i].effect == effect)
            {
                EffectDataHolder data = Effects[i];
                data.effectMultiplier += 0.05f;
                Effects[i] = data;
                continue;
            }
            Effects.Add(holder);
            RecalculateEffects(Effects);*/
    }


    /*private void RecalculateEffects(List<EffectDataHolder> effects)
    {
        EffectDataHolder data;
        int differentElementCount = effects.Count;
        float addition = 0;
        for (int i = Effects.Count - 1; i > 0; i--)
        {
            data = Effects[i];
            addition = data.effectMultiplier - 0.35f;
            if (data.effectMultiplier <= 0)
            {
                data.effectMultiplier = 0.35f - differentElementCount * 0.05f;
                continue;
            }
            else
            {
                data.effectMultiplier = 0.35f - differentElementCount * 0.05f + addition;
            }
            effects[i] = data;
        }
    }*/

    public void DisplayEffects()
    {

        effects.ForEach(effect => Debug.Log($"Effect: {effect.Item1}, multiplier: {effect.Item2}"));
    }

}
