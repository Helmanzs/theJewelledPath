using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPreview : Unit
{
    public Material transparent;
    private Material previewMaterial;
    private Color color;
    private Renderer renderer;
    private void Start()
    {
        this.renderer = GetComponentInChildren<Renderer>();
        this.previewMaterial = new Material(transparent);
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        this.color = renderer.material.color;

        color.a = 0.5f;
        previewMaterial.color = color;
        renderer.material = previewMaterial;
    }
}
