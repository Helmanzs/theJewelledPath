using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpell : SpellCooldown
{
    public override void UseSpell()
    {
        PutOnCooldown();
        foreach (GemBuilding building in Global.Instance.gemBuildings)
        {
            Buff spell = building.gameObject.AddComponent<Buff>();
            spell.Multiplier = 0.9f;
            spell.Seconds = 2;
        }
    }
}
