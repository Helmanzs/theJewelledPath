using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public abstract void Use(Enemy target, float value);

}
