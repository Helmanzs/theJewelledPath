using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : GemBuilding
{
    private LineRenderer lineRendererComponent = null;
    private DrawLine drawLineComponent = null;
    private SphereCollider sphereCollider = null;

    private void Awake()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        drawLineComponent = GetComponent<DrawLine>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
    }

    private void Update()
    {
        if (_primaryTarget != null && lineRendererComponent != null && drawLineComponent != null && gems.Any())
        {
            DrawLine();
        }
        else
        {
            DestroyLine();
        }
    }

    public override Gem ShowcasedGem
    {
        get { return showcasedGem; }
        set
        {
            showcasedGem = value;
            drawLineComponent.ColorBeam();
        }
    }
    protected override void DealDamage()
    {
        if (showcasedGem != null)
        {
            if (nextTimeCall < Time.time)
            {
                nextTimeCall = Time.time + (2 / (1 + (AttackSpeed / 100)));
                UseGemEffect(_primaryTarget, showcasedGem);
                _primaryTarget.ApplyDamage(Damage);
                DrawLine();
            }
        }
    }

    public override void InsertGem(Gem gem)
    {
        this.Damage += gem.Damage;
        this.Range += gem.Range;
        this.AttackSpeed += gem.AttackSpeed;
        if (ShowcasedGem == null)
        {
            this.ShowcasedGem = gem;
        }
        gems.Add(gem);
    }

    protected override void RemoveGem(GameObject gem)
    {
        throw new System.NotImplementedException();
    }

    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
    }

    private void DrawLine()
    {
        if (showcasedGem != null)
        {
            lineRendererComponent.enabled = true;
            drawLineComponent.MakeLine(showcasedGem.transform.position, _primaryTarget.transform.position);
        }

    }
    private void DestroyLine()
    {
        lineRendererComponent.enabled = false;
    }

    protected override void UseGemEffect(Enemy target, Gem gem)
    {
        gem.Effect.Use(target);
    }
}
