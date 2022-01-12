using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera positioning")]
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
    }
}