using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 1.0f;
    [SerializeField] private float zoomSpeed = 1.0f;
    [SerializeField] private float minZoom = 1.0f;
    [SerializeField] private float maxZoom = 10.0f;
    
    private bool isDragging = false;
    private Vector3 lastMouseWorldPos;
    private bool isEnabled = true;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (!isEnabled) return;

        HandleZoom();
        HandleDrag();
    }

    private void HandleZoom()
    {
        float scrollDelta = Input.mouseScrollDelta.y;
        if (scrollDelta != 0)
        {
            float newSize = cam.orthographicSize - scrollDelta * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        }
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseDragStart();
        }
        else if (Input.GetMouseButton(1))
        {
            OnMouseDrag();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            OnMouseDragEnd();
        }
    }

    private void OnMouseDragStart()
    {
        isDragging = true;
        lastMouseWorldPos = GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 currentMouseWorldPos = GetMouseWorldPosition();
        Vector3 worldSpaceDelta = currentMouseWorldPos - lastMouseWorldPos;

        transform.Translate(-worldSpaceDelta.x * dragSpeed, 
                          -worldSpaceDelta.y * dragSpeed, 
                          0);

        lastMouseWorldPos = GetMouseWorldPosition();
    }

    private void OnMouseDragEnd()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -cam.transform.position.z;
        return cam.ScreenToWorldPoint(mouseScreenPos);
    }

    public void SetDragSpeed(float speed)
    {
        dragSpeed = speed;
    }

    public void SetZoomSpeed(float speed)
    {
        zoomSpeed = speed;
    }

    public void SetZoomLimits(float min, float max)
    {
        minZoom = min;
        maxZoom = max;
    }

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
        isDragging = false;
    }

    public Vector3 GetCameraPosition()
    {
        return transform.position;
    }
}