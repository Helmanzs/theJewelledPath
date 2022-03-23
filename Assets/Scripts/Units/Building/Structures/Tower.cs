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
        Gem = new GemHolder();
        lineRendererComponent = GetComponent<LineRenderer>();
        drawLineComponent = GetComponent<DrawLine>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        base.Awake();
    }

    private void Update()
    {
        if (Target != null && lineRendererComponent != null && drawLineComponent != null)
        {
            DrawLine();
        }
        else
        {
            DestroyLine();
        }
    }

    public override void InsertGem(Gem gem)
    {
        Gem.AddGem(gem);
        /*this.Damage += gem.damage;
        this.Range += gem.range;
        this.AttackSpeed += gem.attackSpeed;
        if (ShowcasedGem == null)
        {
            this.ShowcasedGem = gem;
        }
        gems.Add(gem);*/
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
            //drawLineComponent.MakeLine(Gem.transform.position, Target.transform.position);
        }

    }
    private void DestroyLine()
    {
        lineRendererComponent.enabled = false;
    }

    /*protected override void UseGemEffect(Enemy target, Gem gem)
    {
        gem.Effect.Use(target, 0.6f);
    }*/

    public ITargetable<Enemy> FindTarget(TargetMethod method)
    {
        return null;
    }

    public void AddTarget(ITargetable<Enemy> target)
    {

    }

    public void RemoveTarget(ITargetable<Enemy> target)
    {

    }

    protected override void RemoveGem(GemHolder gem)
    {
        Gem = null;
    }

    public Tower Interact()
    {
        return this;
    }


}
