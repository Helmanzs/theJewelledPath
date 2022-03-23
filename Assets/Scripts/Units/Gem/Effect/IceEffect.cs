using UnityEngine;

public class IceEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        target.Speed = target.DefaultSpeed * value;
    }
}
