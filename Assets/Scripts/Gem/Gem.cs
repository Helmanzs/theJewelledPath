using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public Transform _primaryTarget;
    public float range = 7f;
    public int damage = 10;
    private float attackSpeed = 600;
    private float nextTimeCall;


    void Start()
    {
        transform.GetComponent<SphereCollider>().radius = range;
        StartCoroutine(CheckForEnemies());
        nextTimeCall = Time.time + attackSpeed / 1000;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemy();
    }

    void CheckEnemy()
    {
        if (_primaryTarget != null)
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<DrawLine>().MakeLine(this.transform.position, _primaryTarget.transform.position);
            if (Time.time >= nextTimeCall)
            {
                DealDamage();
                nextTimeCall += attackSpeed / 1000;
            }
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
    }

    private void DealDamage()
    {
        if (_primaryTarget != null)
        {
            _primaryTarget.GetComponent<Enemy>().ApplyDamage(5);
        }
    }

    //finds an important target to focus on and caches the reference
    public Transform Target
    {
        get
        {
            if (_primaryTarget == null)
            {
                targets.RemoveAll(eachTarget => { return eachTarget == null; });
                if (targets.Count > 0)
                {
                    _primaryTarget = targets.Find(target => { return true; });
                }
            }

            return _primaryTarget;
        }
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("DefaultEnemy"))
        {

            targets.Add(other.transform);
        }
    }

    IEnumerator CheckForEnemies()
    {
        for (; ; )
        {
            _primaryTarget = Target;
            yield return new WaitForSeconds(.2f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //in case it was the primary target that leaves the Tower's range
        if (ReferenceEquals(_primaryTarget, other.transform))
        {
            _primaryTarget = null;
        }

        targets.Remove(other.transform);
    }
}
