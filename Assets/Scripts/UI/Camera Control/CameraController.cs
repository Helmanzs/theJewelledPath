using System;
using UnityEngine;

public class CameraController : SceneSingleton<CameraController>
{
    public Transform cameraTransform;
    public Transform followTransform;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    private void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
            HandleMovementInput();
            HandleMouseInput();
        }

        if (Input.GetMouseButtonDown(1))
        {
            followTransform = null;
        }
    }

    private void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
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
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
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
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}







/*[Header("Camera positioning")]
public Vector2 cameraOffset = new Vector2(10f, 14f);
public float lookAtOffset = 2f;

[Header("Move controls")]
public float inOutSpeed = 5f;
public float lateralSpeed = 5f;
public float rotateSpeed = 45f;

[Header("Movement Bounds")]
public Vector2 maxBounds;
public Vector2 minBounds;

[Header("Zoom Controls")]
public float zoomSpeed = 10f;
public float nearZoomLimit = 2f;
public float farZoomLimit = 64f;
public float startingZoom = 64f;

IZoomStrategy zoomStrategy;
Vector3 frameMove;
float frameRotate;
float frameZoom;
Camera cam;

private void Awake()
{
    cam = GetComponentInChildren<Camera>();
    cam.transform.localPosition = new Vector3(0f, Mathf.Abs(cameraOffset.y), -Mathf.Abs(cameraOffset.x));
    zoomStrategy = cam.orthographic ? (IZoomStrategy)new OrtographicZoomStrategy(cam, startingZoom) : new PerspectiveZoomStrategy(cam, cameraOffset, startingZoom);
    cam.transform.LookAt(transform.position + Vector3.up * lookAtOffset);
    OnEnable();
}

private void OnEnable()
{
    KeyboardInputManager.OnMoveInput += UpdateFrameMove;
    KeyboardInputManager.OnRotateInput += UpdateFrameRotate;
    KeyboardInputManager.OnZoomInput += UpdateFrameZoom;

    MouseInputManager.OnMoveInput += UpdateFrameMove;
    MouseInputManager.OnRotateInput += UpdateFrameRotate;
    MouseInputManager.OnZoomInput += UpdateFrameZoom;
    MouseInputManager.DragMoveInputHandler += UpdateFrameDrag;
}

private void OnDisable()
{
    KeyboardInputManager.OnMoveInput -= UpdateFrameMove;
    KeyboardInputManager.OnRotateInput -= UpdateFrameRotate;
    KeyboardInputManager.OnZoomInput -= UpdateFrameZoom;

    MouseInputManager.OnMoveInput -= UpdateFrameMove;
    MouseInputManager.OnRotateInput -= UpdateFrameRotate;
    MouseInputManager.OnZoomInput -= UpdateFrameZoom;
    MouseInputManager.DragMoveInputHandler -= UpdateFrameDrag;
}

private void UpdateFrameMove(Vector3 moveVector)
{
    frameMove += moveVector;
}

private void UpdateFrameRotate(float rotateAmount)
{
    frameRotate += rotateAmount;
}

private void UpdateFrameZoom(float zoomAmount)
{
    frameZoom += zoomAmount;
}

private void UpdateFrameDrag(Vector3 moveVector)
{

}

private void LateUpdate()
{
    if (frameMove != Vector3.zero)
    {
        Vector3 speedModFrameMove = new Vector3(frameMove.x * lateralSpeed, frameMove.y, frameMove.z * inOutSpeed);
        transform.position += transform.TransformDirection(speedModFrameMove) * Time.deltaTime;
        //LockPositionInBounds();
        frameMove = Vector3.zero;
    }

    if (frameRotate != 0)
    {
        transform.Rotate(Vector3.up, frameRotate * Time.deltaTime * rotateSpeed);
        frameRotate = 0f;
    }

    if (frameZoom < 0f)
    {
        zoomStrategy.ZoomIn(cam, Time.deltaTime * Mathf.Abs(frameZoom) * zoomSpeed, nearZoomLimit);
        frameZoom = 0f;
    }

    if (frameZoom > 0f)
    {
        zoomStrategy.ZoomOut(cam, Time.deltaTime * frameZoom * zoomSpeed, farZoomLimit);
        frameZoom = 0f;
    }
}

private void LockPositionInBounds()
{
    transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
        transform.position.y,
        Mathf.Clamp(transform.position.z, minBounds.y, maxBounds.y)
        );
}*/
