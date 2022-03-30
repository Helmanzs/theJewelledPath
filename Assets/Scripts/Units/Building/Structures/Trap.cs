using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : GemBuilding, IAreaOfEffectStructure<Enemy>
{
    public List<Enemy> Targets { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void AddTarget(Enemy target)
    {
        throw new System.NotImplementedException();
    }

    public override void Click(Vector3 mousePos)
    {
        throw new System.NotImplementedException();
    }

    public List<Enemy> FindTargets()
    {
        throw new System.NotImplementedException();
    }

    public override void InsertGem(Gem gem)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveTarget(Enemy target)
    {
        throw new System.NotImplementedException();
    }

    protected override void Act()
    {
        throw new System.NotImplementedException();
    }

    protected override void RemoveGem(GemHolder gem)
    {
        throw new System.NotImplementedException();
    }

    protected override void UpdateCollider(float range)
    {
        throw new System.NotImplementedException();
    }
}
