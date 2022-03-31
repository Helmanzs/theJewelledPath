using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Effect
{
    public abstract void Use(Enemy target, float value);
    public abstract void Use(List<Enemy> targets, float value);

}
