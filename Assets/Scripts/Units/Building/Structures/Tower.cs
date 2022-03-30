using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : GemBuilding, ISingleTargetStructure<Enemy>
{
    private Enemy target = null;
    private List<Enemy> possibleTargets = new List<Enemy>();

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

    protected override void Awake()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        drawLineComponent = GetComponent<DrawLine>();
        targetStateManager = GetComponent<TargetStateManager>();

        base.Awake();
    }

    private void FixedUpdate()
    {
        RequestAmplifierModifier(this);

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
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, mousePos));
    }
    protected override void Act()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + (2 / (1 + Gem.AttackSpeed / 100));
            Target.ApplyDamage(Gem.Damage);
            Gem.Effects.ForEach(effect => effect.Item1.Use(Target, effect.Item2));
        }
    }
    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.35f);
        UpdateCollider(Gem.Range);
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
}
