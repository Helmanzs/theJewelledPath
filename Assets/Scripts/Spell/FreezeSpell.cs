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
        Global.enemies.ForEach(enemy => StartCoroutine("SlowEnemy", enemy));
    }
    public IEnumerator SlowEnemy(GameObject enemy)
    {
        float tempSpeed = 0;
        if (enemy != null)
        {
            tempSpeed = enemy.GetComponent<Enemy>().Speed;
            enemy.GetComponent<Enemy>().Speed -= slowAmount;
        }
        yield return new WaitForSeconds(5f);
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().Speed = tempSpeed;
        }
    }


}
