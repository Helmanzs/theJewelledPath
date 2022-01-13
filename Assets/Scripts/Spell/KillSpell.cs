using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpell : SpellCooldown
{
    public override void UseSpell()
    {
        if (IsCooldown)
        {
            return;
        }
        PutOnCooldown();
        for (int i = Global.Instance.enemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = Global.Instance.enemies[i];
            enemy.Kill();
        }
    }


}
