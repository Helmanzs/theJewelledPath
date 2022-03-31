using System;
using UnityEngine;

public class CameraController : SceneSingleton<CameraController>
{
    public Transform cameraTransform;
    public Transform followTransform;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 MouseZoomAmount;
    public Vector3 KeyboardZoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    public bool cameraMoved = false;

    private void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    private void OnCameraMoveClosePanels()
    {
        if (cameraMoved)
            ClickManager.CallCloseAllPanels();
        cameraMoved = false;
    }

    private void Update()
    {
        HandleMovementInput();
        HandleMouseInput();
        OnCameraMoveClosePanels();
    }

    private void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            cameraMoved = true;

            newZoom += Input.mouseScrollDelta.y * MouseZoomAmount;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);
                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                if (newPosition != transform.position)
                {
                    cameraMoved = true;
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            cameraMoved = true;

            rotateCurrentPosition = Input.mousePosition;
            Vector3 difference = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = rotateCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            cameraMoved = true;

            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            cameraMoved = true;

            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cameraMoved = true;

            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cameraMoved = true;

            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cameraMoved = true;

            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cameraMoved = true;

            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if (Input.GetKey(KeyCode.R))
        {
            cameraMoved = true;

            newZoom += KeyboardZoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            cameraMoved = true;

            newZoom -= KeyboardZoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.fixedDeltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.fixedDeltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.fixedDeltaTime * movementTime);
    }
}