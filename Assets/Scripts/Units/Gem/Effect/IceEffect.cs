using UnityEngine;

public class IceEffect : ActiveEffect
{
    public override Effect Clone()
    {
        IceEffect temp = new IceEffect();
        return temp;
    }

    public override void Use(Enemy target, float value)
    {
        target.Speed = target.DefaultSpeed * value;
    }
}
