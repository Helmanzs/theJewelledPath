using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static float GetDistanceToUnit(this Unit unit1, Unit unit2)
    {
        return Vector3.Distance(unit1.transform.position, unit2.transform.position);
    }

    public static T RandomElement<T>(this IEnumerable<T> list)
    {
        return list.ToArray().RandomElement();
    }

    public static T RandomElement<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length - 1)];
    }
}
