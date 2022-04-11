using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

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


}
