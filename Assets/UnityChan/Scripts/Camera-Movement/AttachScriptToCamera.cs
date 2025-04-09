using UnityEngine;

public class AttachScriptToCamera : MonoBehaviour
{
    public string cameraName = "unitychan_hw(Clone)"; // Name of the camera in the Hierarchy

    void Start()
    {
        // Find the camera by name
        GameObject cameraObject = GameObject.Find(cameraName);
        if (cameraObject != null)
        {
            // Check if the CameraZoom script is already attached
            if (cameraObject.GetComponent<CharacterMouseMovement>() == null)
            {
                cameraObject.AddComponent<CharacterMouseMovement>();
                Debug.Log($"CameraZoom script successfully attached to: {cameraObject.name}");
            }
            else
            {
                Debug.Log($"CameraZoom script already exists on: {cameraObject.name}");
            }
        }
        else
        {
            Debug.LogError($"Camera with name '{cameraName}' not found!");
        }
    }
}
