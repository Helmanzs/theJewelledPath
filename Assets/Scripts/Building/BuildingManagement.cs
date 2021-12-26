using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BuildingManagement<T>
{

    protected Selector<T> selector = null;

    private Unit previewedUnit = null;
    protected bool structureBuildingMode = false;
    protected bool gemBuildingMode = false;
    protected T lastPlace = default(T);

    protected Unit PreviewedUnit
    {
        get { return previewedUnit; }
        set
        {
            previewedUnit = value;
            if (value == null)
            {
                structureBuildingMode = false;
                gemBuildingMode = false;
                lastPlace = default(T);
            }
        }
    }

    public void Awake()
    {
        selector = new Selector<T>();
    }

    protected abstract void PreviewUnit();
    protected abstract void AddUnit(T place);
    protected abstract void DeleteUnit(GameObject place, GameObject unit);

}
