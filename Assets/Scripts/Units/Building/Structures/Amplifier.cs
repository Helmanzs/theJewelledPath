using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplifier : GemBuilding, IAreaOfEffectStructure<IAmplifiable>
{
    private List<IAmplifiable> targets = new List<IAmplifiable>();
    private List<IAmplifiable> possibleTargets = new List<IAmplifiable>();
    private float nextTimeCall = 0;

    public List<IAmplifiable> Targets { get => targets; set => targets = value; }
    public List<IAmplifiable> PossibleTargets { get => possibleTargets; set => possibleTargets = value; }

    protected override void Start()
    {
        OnStructurePlaced.AddListener(FindTarget);
        base.Start();
    }

    private void AddModifier(Unit unit)
    {
        Debug.Log(unit, unit);
    }

    private void FindTarget(Unit foundTarget)
    {
        if (foundTarget is Amplifier) return;
        if (sphereCollider.radius == 0) return;

        if (foundTarget.GetDistanceToUnit(this) < 2 * sphereCollider.radius && foundTarget is IAmplifiable)
        {
            IAmplifiable ampl = foundTarget as IAmplifiable;
            ampl.AmplifierModifierRequest += OnAmplifierModifierRequest;
            ampl.Dirty = true;
            possibleTargets.Add(ampl);
        }
    }

    private void OnAmplifierModifierRequest(IAmplifiable structure)
    {
        structure.AmplifierEffect.AddGem(Gem, 0);
    }

    private void FixedUpdate()
    {
        Act();
    }
    public override void EnableGem()
    {
        possibleTargets.ForEach(target => target.Dirty = true);
        base.EnableGem();
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
        possibleTargets.ForEach(target => target.Dirty = true);
        possibleTargets.Clear();
        Global.Instance.gemBuildings.ForEach(building => building.InvokeBuiltStructure());

    }
    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    public void AddTarget(IAmplifiable target)
    {
        PossibleTargets.Add(target);
    }
    public override void AddTarget<T>(T unit)
    {
        if (unit is Amplifier)
        {
            return;
        }
        base.AddTarget(unit);
    }

    public void RemoveTarget(IAmplifiable target)
    {
        target.AmplifierModifierRequest -= OnAmplifierModifierRequest;
        targets.Remove(target);
    }

    public List<IAmplifiable> FindTargets()
    {
        return PossibleTargets;
    }

    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }
}
