using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : GemBuilding, ISingleTargetStructure<Enemy>
{
    private Enemy target = null;

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
                possibleTargets.RemoveAll(target => { return target == null; });
                if (possibleTargets.Count > 0)
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

    protected override void Awake()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        drawLineComponent = GetComponent<DrawLine>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        targetStateManager = GetComponent<TargetStateManager>();
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
        Gem.AddGem(gem);

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
        if (possibleTargets.Count == 0) return null;
        return method.Aim(possibleTargets);
    }

    protected override void DealDamage()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + (2 / (1 + Gem.AttackSpeed / 100));
            Target.ApplyDamage(Gem.Damage);
        }
    }

    public override void RemoveTarget(Enemy target)
    {
        if (ReferenceEquals(Target, target))
        {
            Target = null;
        }
        possibleTargets.Remove(target);
    }

    public override void Click(Vector3 mousePos)
    {
        UIPanel.Instance.OpenPanel(new UnitStatDataHolder(this, this.GetType().Name, Gem.Damage, Gem.Range, Gem.AttackSpeed, mousePos));
    }
}
