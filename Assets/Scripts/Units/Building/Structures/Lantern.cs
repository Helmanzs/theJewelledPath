using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : GemBuilding, IAreaOfEffectStructure<Enemy>, IAmplifiable
{
    public event Action<IAmplifiable> AmplifierModifierRequest;

    private List<Enemy> targets = new List<Enemy>();
    private List<Amplifier> amplifiers = new List<Amplifier>();
    private float nextTimeCall = 0;

    public List<Enemy> Targets
    {
        get
        {
            return targets;
        }
        set => targets = value;
    }

    public GemHolder AmplifierEffect => Gem;

    public List<Amplifier> Amplifiers
    {
        get => amplifiers;
        set => amplifiers = value;
    }

    public void AddTarget(Enemy target)
    {
        Targets.Add(target);
    }

    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, Gem.Effects, mousePos));
    }

    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.5f);
        UpdateCollider(Gem.Range);
        RequestAmplifierModifiers();

    }

    public void RemoveTarget(Enemy target)
    {
        Targets.Remove(target);
    }

    protected override void Act()
    {
        if (targets.Count == 0) return;

        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + 2f;
            Gem.Effects.ForEach(effect => effect.Item1.Use(Targets, effect.Item2));
            Targets.ForEach(target => target.ApplyDamage(Gem.Damage));
            for (int i = targets.Count - 1; i >= 0; i--)
            {
                Enemy target = targets[i];
                if (target == null || target.HP <= 0)
                    targets.Remove(target);
            }
        }
    }

    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }

    public void RequestAmplifierModifiers()
    {
        Gem.ClearAmplifierEffects();
        Amplifiers.Clear();
        AmplifierModifierRequest?.Invoke(this);
    }
}
