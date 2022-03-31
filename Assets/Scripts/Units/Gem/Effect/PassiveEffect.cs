using UnityEngine;
using System;

[Serializable]
public abstract class PassiveEffect : Effect
{
    public abstract override void Use(Enemy target, float value);
}
