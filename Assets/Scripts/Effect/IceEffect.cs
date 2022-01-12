using UnityEngine;

public class IceEffect : ActiveEffect
{
    public override void Use(Unit target)
    {
        target.GetComponent<Enemy>().Speed = 0;
    }
}
