using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : GemBuilding, IAreaOfEffectStructure<Enemy>, IAmplifiable
{
    public event Action<IAmplifiable> AmplifierModifierRequest;

    private List<Enemy> targets = new List<Enemy>();
    private GemHolder amplifierEffect;
    private float amplifierNumberEffect = 0;
    private List<Amplifier> amplifiers = new List<Amplifier>();
    private float nextTimeCall = 0;

    public List<Enemy> Targets
    {
        get => targets;
        set => targets = value;
    }

    public GemHolder AmplifierEffect { get => amplifierEffect; set => amplifierEffect = value; }
    public float AmplifierNumberEffect { get => amplifierNumberEffect; set => amplifierNumberEffect = value; }
    public List<Amplifier> Amplifiers { get => amplifiers; set => amplifiers = value; }

    public void AddTarget(Enemy target)
    {
        Targets.Add(target);
    }

    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, mousePos));
    }

    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.5f);
    }

    public void RemoveTarget(Enemy target)
    {
        Targets.Remove(target);
    }

    protected override void Act()
    {
        if (Targets.Count <= 0) return; 

        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + 0.5f;
            Gem.Effects.ForEach(effect => effect.Item1.Use(Targets, effect.Item2));
            Targets.ForEach(target => target.ApplyDamage(Gem.Damage));
            Targets.RemoveAll(target => { return target == null; });
        }
    }

    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    protected override void UpdateCollider(float range)
    {
        return;
    }
}
