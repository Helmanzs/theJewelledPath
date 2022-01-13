using UnityEngine;

public class IceEffect : ActiveEffect
{
    public override void Use(Enemy target)
    {
        target.Speed -= 100;
    }
}
