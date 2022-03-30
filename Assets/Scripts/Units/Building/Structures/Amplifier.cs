using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplifier : GemBuilding, IAreaOfEffectStructure<Structure>
{
    private List<Structure> targets = new List<Structure>();
    private List<Structure> possibleTargets = new List<Structure>();
    private float nextTimeCall = 0;


    public List<Structure> Targets { get => targets; set => targets = value; }
    public List<Structure> PossibleTargets { get => possibleTargets; set => possibleTargets = value; }

    protected override void Start()
    {
        OnStructurePlaced.AddListener(FindTarget);
        base.Start();
    }
    protected override void Awake()
    {
        base.Awake();
    }
    private void FindTarget(Unit foundTarget)
    {
        if (foundTarget is Amplifier) return;
        if (sphereCollider.radius == 0) return;

        print($"Distance to target: {foundTarget.GetDistanceToUnit(this)}, radius: {2 * sphereCollider.radius}");
        if (foundTarget.GetDistanceToUnit(this) < 2 * sphereCollider.radius)
        {
            possibleTargets.Add(foundTarget as Structure);
        }
    }

    private void FixedUpdate()
    {
        Act();
    }
    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, mousePos));
    }
    protected override void Act()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + 1;
            Targets = FindTargets();
        }
    }
    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.2f);
        UpdateCollider(Gem.Range);
        possibleTargets.Clear();
        Global.Instance.gemBuildings.ForEach(building => building.InvokeBuiltStructure());

    }
    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    public void AddTarget(Structure target)
    {
        PossibleTargets.Add(target);
    }
    public override void AddTarget<T>(T unit)
    {
        if (unit is Amplifier)
        {
            return;
        }
        base.AddTarget<T>(unit);
    }

    public void RemoveTarget(Structure target)
    {
        targets.Remove(target);
    }

    public List<Structure> FindTargets()
    {

        return new List<Structure>(PossibleTargets);
    }

    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }
}
