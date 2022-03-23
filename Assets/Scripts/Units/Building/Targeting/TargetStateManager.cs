using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetStateManager : MonoBehaviour
{
    private TargetMethod defaultMethod = TargetMethod.LeastHP;

    public event Action<Method> TargetingMethodChanged;
    private Structure structure;

    private Method currentMethod;
    private List<Method> pastMethods = new List<Method>();

    private static Dictionary<TargetMethod, Type> methods = new Dictionary<TargetMethod, Type> {
        { TargetMethod.Closest, typeof(MethodClosest) },
        { TargetMethod.MostHP, typeof(MethodMostHP) },
        { TargetMethod.Furthest, typeof(MethodFurthest) },
        { TargetMethod.Random, typeof(MethodRandom) },
        { TargetMethod.Boss, typeof(MethodBoss) },
        { TargetMethod.LeastHP, typeof(MethodLeastHp) },
        { TargetMethod.Building, typeof(MethodBuilding) }
    };

    private void Start()
    {
        structure = GetComponent<Structure>();
        ChangeMethod(defaultMethod);
    }
    public void ChangeMethod(TargetMethod newMethod)
    {
        if (currentMethod)
        {
            currentMethod.enabled = false;
        }
        if (!pastMethods.Exists(x => x.GetType() == methods[newMethod]))
        {
            currentMethod = gameObject.AddComponent(methods[newMethod]) as Method;
            pastMethods.Add(currentMethod);
        }
        else
        {
            currentMethod = pastMethods.First(x => x.GetType() == methods[newMethod]);
            currentMethod.enabled = true;
        }
        currentMethod.InitState(structure);
    }
}
public enum TargetMethod
{
    Closest,
    MostHP,
    Furthest,
    Random,
    Boss,
    LeastHP,
    Building
}
