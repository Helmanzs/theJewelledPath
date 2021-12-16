using UnityEngine;

public class IceEffect : Effect
{
    public override void Use(Enemy target)
    {
        target.Speed = 0;
    }
}
