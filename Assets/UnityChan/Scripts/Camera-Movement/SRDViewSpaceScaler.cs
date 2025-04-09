using UnityEngine;
using SRD.Core;

public class SRDViewSpaceScaler : MonoBehaviour
{
    public SRDManager srdManager; // Reference to the SRD Manager component
    public float minScale = 7f; // Minimum viewspace scale
    public float maxScale = 18f; // Maximum viewspace scale
    public float scrollSpeed = 99999999999999999999f; // Speed of scaling adjustment

    void Start()
    {
        // Ensure the SRDManager reference is set
        if (srdManager == null)
        {
            srdManager = GetComponent<SRDManager>();
        }

        if (srdManager == null)
        {
            Debug.LogError("SRDManager component is missing! Please attach this script to the SRDisplayManager object.");
        }
    }

    void Update()
    {
        if (srdManager != null)
        {
            // Get scroll input
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            if (scrollInput != 0)
            {
                if (scrollInput > 0)
                {
                    float newScale = srdManager.SRDViewSpaceScale - 0.5f;
                    srdManager.SRDViewSpaceScale = Mathf.Clamp(newScale, minScale, maxScale);
                }
                else
                {
                    float newScale = srdManager.SRDViewSpaceScale + 0.5f;
                    srdManager.SRDViewSpaceScale = Mathf.Clamp(newScale, minScale, maxScale);
                }
            }
        }
    }
}
