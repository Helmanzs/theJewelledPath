using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BuildingManagement<T>
{

    protected Selector<T> selector = null;

    private Unit unit = null;
    private Unit unitPreview = null;
    protected bool structureBuildingMode = false;
    protected bool gemBuildingMode = false;
    protected T lastPlace = default(T);

    protected Unit Unit
    {
        get { return unit; }
        set
        {
            unit = value;
            if (unit == null)
            {
                structureBuildingMode = false;
                gemBuildingMode = false;
                lastPlace = default(T);
                UnitPreview = null;
            }
        }
    }

    protected Unit UnitPreview { get => unitPreview; set => unitPreview = value; }

    public void Awake()
    {
        selector = new Selector<T>();
    }

    protected abstract void PreviewUnit();
    protected abstract void AddUnit(T place);
    protected abstract void DeleteUnit(T place, T unit);

    protected abstract void ShowcaseUnit(T place);

    protected void DeleteShowcasedUnit()
    {

        GameObject.Destroy(UnitPreview.gameObject);
        GameObject.Destroy(Unit.gameObject);
        Unit = null;
    }

}
