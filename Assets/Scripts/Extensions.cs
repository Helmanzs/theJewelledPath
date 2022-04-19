using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using UnityEngine;

public static class Extensions
{
    public static float GetDistanceToUnit(this Unit unit1, Unit unit2)
    {
        return UnityEngine.Vector3.Distance(unit1.transform.position, unit2.transform.position);
    }

    public static T RandomElement<T>(this IEnumerable<T> list)
    {
        return list.ToArray().RandomElement();
    }

    public static T RandomElement<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length - 1)];
    }
    public static Texture2D RotateTexture(this Texture2D originalTexture, bool clockwise)
    {
        Color32[] original = originalTexture.GetPixels32();
        Color32[] rotated = new Color32[original.Length];
        int w = originalTexture.width;
        int h = originalTexture.height;

        int iRotated, iOriginal;

        for (int j = 0; j < h; ++j)
        {
            for (int i = 0; i < w; ++i)
            {
                iRotated = (i + 1) * h - j - 1;
                iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                rotated[iRotated] = original[iOriginal];
            }
        }

        Texture2D rotatedTexture = new Texture2D(h, w);
        rotatedTexture.SetPixels32(rotated);
        rotatedTexture.Apply();
        return rotatedTexture;
    }

    public static string ToKMB(this BigInteger num)
    {
        if (num > 999999999999999999 || num < -999999999999999999)
        {
            return num.ToString("0,,,,,,.0##Qi", CultureInfo.InvariantCulture);
        }
        else
        if (num > 999999999999999 || num < -999999999999999)
        {
            return num.ToString("0,,,,,.0##Qa", CultureInfo.InvariantCulture);
        }
        else
        if (num > 999999999999 || num < -999999999999)
        {
            return num.ToString("0,,,,.0##T", CultureInfo.InvariantCulture);
        }
        else
        if (num > 999999999 || num < -999999999)
        {
            return num.ToString("0,,,.0##B", CultureInfo.InvariantCulture);
        }
        else
        if (num > 999999 || num < -999999)
        {
            return num.ToString("0,,.0#M", CultureInfo.InvariantCulture);
        }
        else
        if (num > 999 || num < -999)
        {
            return num.ToString("0,.0K", CultureInfo.InvariantCulture);
        }
        else
        {
            return num.ToString(CultureInfo.InvariantCulture);
        }
    }
    public static string ToKMB(this int num)
    {
        return ((BigInteger)num).ToKMB();
    }
    public static string ToKMB(this float num)
    {
        return ((BigInteger)num).ToKMB();
    }
    public static string ToKMB(this double num)
    {
        return ((BigInteger)num).ToKMB();
    }
    public static string ToKMB(this long num)
    {
        return ((BigInteger)num).ToKMB();
    }
    public static string ToKMB(this ulong num)
    {
        return ((BigInteger)num).ToKMB();
    }

}
