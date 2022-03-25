using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplifier : GemBuilding
{
    /*private Dictionary<Effect, float> effects = new Dictionary<Effect, float>();
    private List<GemBuilding> affectedBuildings = new List<GemBuilding>();

    private SphereCollider sphereCollider = null;

    private void Awake()
    {
        sphereCollider = GetComponentInChildren<SphereCollider>();
    }

    public override void InsertGem(Gem gem)
    {
        RecalculateEffects();
        effects.Add(gem.Effect, 0);
    }

    private void RecalculateEffects()
    {

    }

    protected override void DealDamage()
    {
        throw new System.NotImplementedException();
    }


    protected override void UpdateCollider(float range)
    {
        sphereCollider.radius = range / 2;
        affectedBuildings = GetBuildingsInRange();

    }

    private List<GemBuilding> GetBuildingsInRange()
    {
        return null;
    }

    protected override void UseGemEffect(Enemy target, Gem gem)
    {
        throw new System.NotImplementedException();
    }

    protected override void RemoveGem(GameObject gem)
    {
        throw new System.NotImplementedException();
    }*/
    public override void InsertGem(Gem gem)
    {
        throw new NotImplementedException();
    }

    public override void RemoveTarget(Enemy target)
    {
        throw new NotImplementedException();
    }

    protected override void DealDamage()
    {
        throw new NotImplementedException();
    }

    protected override void RemoveGem(GemHolder gem)
    {
        throw new NotImplementedException();
    }

    protected override void UpdateCollider(float range)
    {
        throw new NotImplementedException();
    }
}
