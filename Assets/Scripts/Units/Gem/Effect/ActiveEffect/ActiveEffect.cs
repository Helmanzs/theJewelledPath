using UnityEngine;
using System;

[Serializable]
public abstract class ActiveEffect : Effect
{
    public abstract override void Use(Enemy target, float value);
}
