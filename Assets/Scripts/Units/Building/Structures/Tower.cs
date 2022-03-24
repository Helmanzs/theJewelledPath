using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : GemBuilding, ISingleTargetStructure<Enemy>, ITargetable<Tower>
{
    private Enemy target = null;
    private LineRenderer lineRendererComponent = null;
    private DrawLine drawLineComponent = null;
    private SphereCollider sphereCollider = null;
    private TargetStateManager targetStateManager = null;
    private float nextTimeCall;

    public bool TestMethod = false;

    public Enemy Target
    {
        get => target;
        set
        {
            target = value;
            drawLineComponent.ColorBeam();
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
        if (possibleTargets.Count == 0) return;
        if (TestMethod)
        {
            targetStateManager.ChangeMethod(TargetMethod.MostHP);
        }
        Target = FindTarget(targetStateManager.CurrentMethod);
        DrawLine();
        DealDamage();
        if (Target == null)
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
        if (Gem != null)
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

    public Tower Interact()
    {
        return this;
    }

    public Enemy FindTarget(Method method)
    {
        return method.Aim(possibleTargets);
    }

    protected override void DealDamage()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + (2 / (1 + (Gem.AttackSpeed / 100)));
            Target.ApplyDamage(Gem.Damage);
        }
    }
}
