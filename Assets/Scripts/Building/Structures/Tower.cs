using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GemBuilding
{
    GameObject previewGem = null;

    protected override void DealDamage(GameObject enemy)
    {
        throw new System.NotImplementedException();
    }

    protected override void InsertGem(GameObject gem)
    {
        Gem gemStats = gem.GetComponent<Gem>();
        this.Damage += gemStats.Damage;
        this.Range += gemStats.Range;
        this.AttackSpeed = 1500;

        previewGem = gem;
    }

    protected override void RemoveGem(GameObject gem)
    {
        throw new System.NotImplementedException();
    }

    protected override void UpdateCollider(float range)
    {
        SphereCollider sc = this.transform.GetComponent<SphereCollider>();
        sc.radius = range/100;
    }
}
