using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpell : SpellCooldown
{
    public override void UseSpell()
    {
        if (IsCooldown)
        {
            return;
        }
        PutOnCooldown();
        Global.Instance.enemies.ForEach(enemy => SlowEnemy(enemy));
    }
    public void SlowEnemy(Enemy enemy)
    {
        if (enemy is Boss) return;
        Chill chillComponent = enemy.gameObject.AddComponent<Chill>();
        chillComponent.Multiplier = 0.2f;
        chillComponent.RefreshDuration(5);
    }
}
