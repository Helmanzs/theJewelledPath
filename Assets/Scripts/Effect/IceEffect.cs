using UnityEngine;

public class IceEffect : Effect
{
    public override void Use(GameObject target)
    {
        target.GetComponent<Enemy>().Speed = 0;
    }
}
