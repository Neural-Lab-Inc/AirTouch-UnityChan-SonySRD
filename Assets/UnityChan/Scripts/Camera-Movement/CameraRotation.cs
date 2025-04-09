using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float zoomSpeed = 10f;  // Speed at which the camera zooms
    public float minZoom = -10f;  // Minimum Z position
    public float maxZoom = 10f;   // Maximum Z position

    private float currentZoom = 0f; // Current Z position offset

    void Update()
    {
        Debug.Log("CameraZoom Update running.");
        // Get vertical mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * zoomSpeed * Time.deltaTime;

        // Update zoom position
        currentZoom -= mouseY;  // Subtract to make upward movement zoom in
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); // Clamp the zoom position

        // Apply the zoom to the camera's position
        Vector3 newPosition = transform.localPosition;
        newPosition.z = currentZoom;
        transform.localPosition = newPosition;
    }
}
