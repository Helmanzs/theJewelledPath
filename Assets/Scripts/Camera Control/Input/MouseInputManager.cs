using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : InputManager
{
    public static event MoveInputHandler OnMoveInput;
    public static event RotateInputHandler OnRotateInput;
    public static event ZoomInputHandler OnZoomInput;
    public static event MoveInputHandler DragMoveInputHandler;

    Vector2Int screen;
    float mousePositionOnRotateStart;

    Vector3 dragOrigin;
    Vector3 dragCurrent;
    bool isDragging;


    private void Awake()
    {
        screen = new Vector2Int(Screen.width, Screen.height);
    }

    private void Update()
    {
        Vector3 mp = Input.mousePosition;
        //dragOrigin = Input.mousePosition;

        bool mouseValid = (mp.y <= screen.y * 1.05f && mp.y >= screen.y * -0.05f) && mp.x <= screen.x * 1.05f && mp.x >= screen.x * -0.05;

        if (!mouseValid)
        {
            return;
        }

        //movement on edge
        if (mp.y > screen.y * 0.95)
        {
            OnMoveInput?.Invoke(Vector3.forward);
        }
        else if (mp.y < screen.y * 0.05f)
        {
            OnMoveInput?.Invoke(-Vector3.forward);
        }

        if (mp.x > screen.x * 0.95)
        {
            OnMoveInput?.Invoke(Vector3.right);
        }
        else if (mp.x < screen.x * 0.05f)
        {
            OnMoveInput?.Invoke(-Vector3.right);
        }

        //rotate
        if (Input.GetMouseButtonDown(1))
        {
            mousePositionOnRotateStart = mp.x;
        }
        else if (Input.GetMouseButton(1))
        {
            if (mp.x < mousePositionOnRotateStart)
            {
                OnRotateInput?.Invoke(-1f);
            }
            else if (mp.x > mousePositionOnRotateStart)
            {
                OnRotateInput?.Invoke(1f);
            }
        }

        //zoom
        if (Input.mouseScrollDelta.y > 0)
        {
            OnZoomInput?.Invoke(-15f);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            OnZoomInput?.Invoke(15f);
        }
    }
}
