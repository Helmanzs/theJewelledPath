using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EffectDataHolder
{
    private Effect effect;
    private float effectMultiplier;

    public Effect Effect { get => effect; set => effect = value; }
    public float EffectMultiplier { get => effectMultiplier; set => effectMultiplier = value; }

    public EffectDataHolder(Effect effect, float value)
    {
        this.effect = effect;
        this.effectMultiplier = value;
    }
}
