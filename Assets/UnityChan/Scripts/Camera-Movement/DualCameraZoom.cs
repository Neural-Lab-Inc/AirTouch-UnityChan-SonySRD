using UnityEngine;

public class DualCameraZoom : MonoBehaviour
{
    public GameObject cameraObject; // Assign the camera in the Inspector
    public string targetObjectName = "Center"; // Name of the object to rotate around (find it by name)
    public float rotationSpeed = 50f; // Speed of rotation
    public float zoomStep = 1f; // Amount to zoom in/out with each scroll
    public float minZoom = 1f; // Minimum zoom distance
    public float maxZoom = 100f; // Maximum zoom distance

    private Transform target; // The target to rotate around
    private float currentZoom; // Tracks the current zoom level

    void Start()
    {
        // Find the target by name
        target = GameObject.Find(targetObjectName)?.transform;

        // Check if the target was found
        if (target == null)
        {
            Debug.LogError($"Target with name '{targetObjectName}' not found in the scene!");
            return;
        }
    }

    void Update()
    {
        // Rotation: only when the left mouse button is held down
        if (Input.GetMouseButton(0) && target != null) // 0 is the left mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = 0;

            // Rotate the camera around the target
            RotateCameraAroundTarget(mouseX, mouseY);
        }
    }

    void RotateCameraAroundTarget(float mouseX, float mouseY)
    {
        if (cameraObject != null && target != null)
        {
            // Get current rotation of the camera and target
            Vector3 targetPosition = target.position;

            // Calculate the rotation around the target
            float rotationAroundY = mouseX;
            float rotationAroundX = -mouseY;

            // Rotate around the Y-axis (horizontal rotation)
            cameraObject.transform.RotateAround(targetPosition, Vector3.up, rotationAroundY);

            // Rotate around the X-axis (vertical rotation)
            // Restrict vertical rotation to avoid flipping
            float desiredXRotation = cameraObject.transform.eulerAngles.x + rotationAroundX;
            if (desiredXRotation < 80f || desiredXRotation > 280f)
            {
                cameraObject.transform.RotateAround(targetPosition, cameraObject.transform.right, rotationAroundX);
            }
        }
        else
        {
            Debug.LogError("Camera or target reference is missing!");
        }
    }
}
