using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BuildingManagement<T>
{

    protected Selector<T> selector = null;

    private Unit unit = null;
    private Unit unitPreview = null;
    protected bool buildingMode = false;
    protected T lastPlace = default(T);


    protected Unit Unit
    {
        get { return unit; }
        set
        {
            unit = value;
        }
    }

    protected Unit UnitPreview { get => unitPreview; set => unitPreview = value; }

    public void Awake()
    {
        selector = new Selector<T>();
    }

    public void Update()
    {
        if (buildingMode)
        {
            PreviewUnit();
            if (Input.GetMouseButton(0))
            {
                AddUnit(lastPlace);
            }
            else if (Input.GetMouseButton(1))
            {
                if (lastPlace != null)
                {
                    DeleteShowcasedUnit();
                    buildingMode = false;
                }
            }
        }
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
