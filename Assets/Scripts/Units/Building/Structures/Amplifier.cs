using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplifier : GemBuilding, IAreaOfEffectStructure<Structure>
{
    private List<Structure> targets = new List<Structure>();
    private List<Structure> possibleTargets = new List<Structure>();

    private SphereCollider sphereCollider = null;

    public List<Structure> Targets { get => targets; set => targets = value; }
    protected new List<Structure> PossibleTargets { get => possibleTargets; set => possibleTargets = value; }

    protected override void Awake()
    {
        sphereCollider = GetComponentInChildren<SphereCollider>();
        sphereCollider.gameObject.AddComponent<GemBuildingTrigger>();
    }

    public void AddTarget(Structure target)
    {
        PossibleTargets.Add(target);
    }

    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, mousePos));
    }

    public List<Structure> FindTargets()
    {
        return new List<Structure>(PossibleTargets);
    }

    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.2f);
    }

    public void RemoveTarget(Structure target)
    {
        targets.Remove(target);
    }

    protected override void DealDamage()
    {
        Targets = FindTargets();
    }

    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }

    public override void AddTarget<T>(T unit)
    {
        if (unit is Amplifier)
        {
            return;
        }
        base.AddTarget<T>(unit);
    }
}
