using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpell : SpellCooldown
{
    public float slowAmount = 1000f;
    public override void UseSpell()
    {
        if (IsCooldown)
        {
            return;
        }
        PutOnCooldown();
        Global.Instance.enemies.ForEach(enemy => StartCoroutine("SlowEnemy", enemy));
    }
    public IEnumerator SlowEnemy(Enemy enemy)
    {
        float tempSpeed = 0;
        if (enemy != null)
        {
            tempSpeed = enemy.Speed;
            enemy.Speed -= slowAmount;
        }
        yield return new WaitForSeconds(5f);
        if (enemy != null)
        {
            enemy.Speed = tempSpeed;
        }
    }


}
