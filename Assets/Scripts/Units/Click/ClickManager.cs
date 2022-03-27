using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public static event Action CloseAllPanels = delegate { };

    public Canvas canvas;
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    private PointerEventData eventData;

    private void Awake()
    {
        eventData = new PointerEventData(null);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, float.PositiveInfinity, ~(1 << 31));
            if (hit && hitInfo.collider.TryGetComponent(out IClickable clickable))
            {
                clickable?.Click(Input.mousePosition);
            }
            else
            {
                CloseAllPanels();
            }
        }
    }
    public static void CallCloseAllPanels()
    {
        CloseAllPanels();
    }
}
