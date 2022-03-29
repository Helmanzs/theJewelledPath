using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetStateManager : MonoBehaviour
{
    private TargetMethod defaultMethod = TargetMethod.Closest;

    private Structure structure;
    private Method currentMethod;
    private TargetMethod targetMethodPointer = TargetMethod.Closest;

    public Method CurrentMethod => currentMethod;
    public TargetMethod TargetMethodPointer => targetMethodPointer;

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

    public static Dictionary<TargetMethod, Type> Methods => methods;
    public static Dictionary<TargetMethod, Type> GetMethod => methods;

    private void Start()
    {
        structure = GetComponent<Structure>();
        ChangeMethod(defaultMethod);

    }
    private void Awake()
    {
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
        targetMethodPointer = newMethod;
        currentMethod.InitState(structure);
    }
}
