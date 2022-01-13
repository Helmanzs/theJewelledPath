using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Color mainColor;
    private Color darkerColor;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void MakeLine(Vector3 pos1, Vector3 pos2)
    {
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);
    }

    public void ColorBeam()
    {
        mainColor = GetComponentInParent<GemBuilding>().ShowcasedGem.Color;
        darkerColor = new Color(mainColor.r * 0.1f, mainColor.g * 0.1f, mainColor.b * 0.1f);

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(mainColor, 0.0f), new GradientColorKey(darkerColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;

    }
}
