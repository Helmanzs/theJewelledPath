using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GemBuilding
{
    private LineRenderer ld = null;
    private DrawLine dl = null;
    private SphereCollider sc = null;

    private void Awake()
    {
        ld = GetComponent<LineRenderer>();
        dl = GetComponent<DrawLine>();
        sc = GetComponentInChildren<SphereCollider>();
    }

    protected override void DealDamage()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + (1 - AttackSpeed / 1000);
            _primaryTarget.GetComponent<Enemy>().ApplyDamage(Damage);
            DrawLine();
            UseGemEffect(_primaryTarget.gameObject, showcasedGem);
        }

    }

    private void Update()
    {
        if (_primaryTarget != null && ld != null && dl != null)
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
        Gem gemStats = gem.GetComponent<Gem>();
        this.Damage += gemStats.Damage;
        this.Range += gemStats.Range;
        this.AttackSpeed += gemStats.AttackSpeed;
        gems.Add(gem);
    }

    protected override void RemoveGem(GameObject gem)
    {
        throw new System.NotImplementedException();
    }

    protected override void UpdateCollider(float range)
    {
        sc.radius = range / 2;
    }

    private void DrawLine()
    {

        ld.enabled = true;
        dl.MakeLine(showcasedGem.transform.position, _primaryTarget.transform.position);

    }
    private void DestroyLine()
    {
        ld.enabled = false;
    }

    protected override void UseGemEffect(GameObject target, Gem gem)
    {
        //gem.Effect.Use(target);
    }
}
