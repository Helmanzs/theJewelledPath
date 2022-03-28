using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EffectDataHolder
{
    public Effect effect;
    public float effectMultiplier;

    public EffectDataHolder(Effect effect, float value)
    {
        this.effect = effect;
        this.effectMultiplier = value;
    }
}
