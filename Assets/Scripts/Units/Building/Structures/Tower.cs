using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : GemBuilding, ISingleTargetStructure<Enemy>, IAmplifiable
{
    public event Action<IAmplifiable> AmplifierModifierRequest;

    private Enemy target = null;
    private List<Enemy> possibleTargets = new List<Enemy>();
    private List<Amplifier> amplifiers = new List<Amplifier>();

    private LineRenderer lineRendererComponent = null;
    private DrawLine drawLineComponent = null;
    private TargetStateManager targetStateManager = null;

    private float nextTimeCall = 0;

    public Enemy Target
    {
        get
        {
            if (target == null)
            {
                PossibleTargets.RemoveAll(target => { return target == null; });
                if (PossibleTargets.Count > 0)
                {
                    target = FindTarget(targetStateManager.CurrentMethod);
                }
            }
            return target;
        }
        set
        {
            target = value;
        }
    }
    public List<Enemy> PossibleTargets { get => possibleTargets; set => possibleTargets = value; }
    public GemHolder AmplifierEffect
    {
        get => Gem;
    }

    public List<Amplifier> Amplifiers { get => amplifiers; set => amplifiers = value; }

    protected override void Awake()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        drawLineComponent = GetComponent<DrawLine>();
        targetStateManager = GetComponent<TargetStateManager>();

        base.Awake();
    }

    protected override void FixedUpdate()
    {
        if (Target != null)
        {
            DrawLine();
            Act();
        }
        else
        {
            DestroyLine();
        }
    }
    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, Gem.Effects, mousePos));
    }
    protected override void Act()
    {
        if (nextTimeCall < Time.time)
        {
            float multi = 0;
            nextTimeCall = Time.time + (2 / (1 + Gem.AttackSpeed / 100));
            foreach (Tuple<Effect, float> effect in Gem.Effects)
            {
                Gem.SumEffects(effect.Item1, ref multi);
                effect.Item1.Use(Target, multi);
                multi = 0;
            }
            Gem.Effects.ForEach(effect => effect.Item1.Use(Target, effect.Item2));
            Target.ApplyDamage(Gem.Damage);
        }
    }
    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.35f);
        UpdateCollider(Gem.Range);
        RequestAmplifierModifiers();

    }
    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }
    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }

    private void DrawLine()
    {
        if (!Gem.isActiveAndEnabled && Target == null)
            return;

        drawLineComponent.ColorBeam();
        lineRendererComponent.enabled = true;
        drawLineComponent.MakeLine(Gem.transform.position, Target.transform.position);
    }
    private void DestroyLine()
    {
        lineRendererComponent.enabled = false;
    }
    public Enemy FindTarget(Method method)
    {
        if (PossibleTargets.Count == 0) return null;
        return method.Aim(PossibleTargets);
    }

    public void RemoveTarget(Enemy target)
    {
        if (ReferenceEquals(Target, target))
        {
            Target = null;
        }
        PossibleTargets.Remove(target);
    }

    public void AddTarget(Enemy target)
    {
        PossibleTargets.Add(target);
    }
    public void RequestAmplifierModifiers()
    {
        Gem.ClearAmplifierEffects();
        Amplifiers.Clear();
        AmplifierModifierRequest?.Invoke(this);
    }
}
