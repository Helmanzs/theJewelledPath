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
    private SphereCollider sphereCollider = null;
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

    protected override List<Enemy> PossibleTargets { get => possibleTargets; set => possibleTargets = value; }
    protected override void Awake()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        drawLineComponent = GetComponent<DrawLine>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        targetStateManager = GetComponent<TargetStateManager>();
        sphereCollider.gameObject.AddComponent<GemBuildingTrigger>();
        base.Awake();
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            DrawLine();
            DealDamage();
        }
        else
        {
            DestroyLine();
        }
    }

    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem, 0.35f);
    }

    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }

    private void DrawLine()
    {
        drawLineComponent.ColorBeam();
        if (Gem.isActiveAndEnabled && Target != null)
        {
            lineRendererComponent.enabled = true;
            drawLineComponent.MakeLine(Gem.transform.position, Target.transform.position);
        }

    }
    private void DestroyLine()
    {
        lineRendererComponent.enabled = false;
    }

    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    public Enemy FindTarget(Method method)
    {
        if (PossibleTargets.Count == 0) return null;
        return method.Aim(PossibleTargets);
    }

    protected override void DealDamage()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + (2 / (1 + Gem.AttackSpeed / 100));
            Target.ApplyDamage(Gem.Damage);
            Gem.Effects.ForEach(effect => effect.Item1.Use(Target, effect.Item2));
        }
    }
    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, mousePos));
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
