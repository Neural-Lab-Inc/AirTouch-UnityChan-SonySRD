using UnityEngine;
using System.Collections;

public class ActivateEffectsOnMiddleClick : MonoBehaviour
{
    // Assign the four Particle Systems in the Inspector
    public ParticleSystem effect1;
    public ParticleSystem effect2;
    public ParticleSystem effect3;
    public ParticleSystem effect4;

    private GameObject followTarget; // Reference to unitychan_hw(Clone)

    void Start()
    {
        // Find the target by name
        followTarget = GameObject.Find("unitychan_hw(Clone)");

        // Set initial positions for all the effects
        if (followTarget != null)
        {
            Vector3 targetPosition = followTarget.transform.position;
            Vector3 effectPosition1 = new Vector3(targetPosition.x - 1, 2, targetPosition.z);
            Vector3 effectPosition3 = new Vector3(targetPosition.x + 1, 2, targetPosition.z);
            Vector3 effectPosition2 = new Vector3(targetPosition.x, 1, targetPosition.z);
            SetEffectsPosition(effectPosition1, effectPosition2, effectPosition3);
        }
    }

    void Update()
    {
        // Continuously update the position of the effects to follow the target's X and Z
        if (followTarget != null)
        {
            Vector3 targetPosition = followTarget.transform.position;
            Vector3 effectPosition1 = new Vector3(targetPosition.x - 1, 1, targetPosition.z);
            Vector3 effectPosition3 = new Vector3(targetPosition.x + 1, 1, targetPosition.z);
            Vector3 effectPosition2 = new Vector3(targetPosition.x, 1, targetPosition.z);
            SetEffectsPosition(effectPosition1, effectPosition2, effectPosition3);
        }

        // Check if the middle mouse button (scroll wheel click) is pressed
        if (Input.GetMouseButtonDown(2)) // 2 is the middle mouse button (scroll wheel click)
        {
            ActivateEffects();
        }
    }

    // Function to activate all the particle effects
    void ActivateEffects()
    {
        // Check if the particle systems are already playing
        if (effect1 != null && !effect1.isPlaying)
        {
            effect1.gameObject.SetActive(true);
            effect1.Play();
        }
        if (effect2 != null && !effect2.isPlaying)
        {
            effect2.gameObject.SetActive(true);
            effect2.Play();
        }
        if (effect3 != null && !effect3.isPlaying)
        {
            effect3.gameObject.SetActive(true);
            effect3.Play();
        }
        if (effect4 != null && !effect4.isPlaying)
        {
            effect4.gameObject.SetActive(true);
            effect4.Play();
        }

        // Debug: Log the activation
        Debug.Log("Effects Activated");

        // Start the coroutine to disable the effects after 3 seconds
        StartCoroutine(DisableEffectsAfterDelay(4.5f));
    }

    // Coroutine to disable the effects after the given delay
    IEnumerator DisableEffectsAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Debug: Log when disabling effects
        Debug.Log("Disabling Effects after 3 seconds");

        // Disable all the effects after the delay
        if (effect1 != null)
        {
            effect1.Stop();
            effect1.gameObject.SetActive(false);
        }
        if (effect2 != null)
        {
            effect2.Stop();
            effect2.gameObject.SetActive(false);
        }
        if (effect3 != null)
        {
            effect3.Stop();
            effect3.gameObject.SetActive(false);
        }
        if (effect4 != null)
        {
            effect4.Stop();
            effect4.gameObject.SetActive(false);
        }
    }

    // Helper function to set the position of all effects
    void SetEffectsPosition(Vector3 position1, Vector3 position2, Vector3 position3)
    {
        if (effect1 != null) effect1.transform.position = position1;
        if (effect2 != null) effect2.transform.position = position2;
        if (effect3 != null) effect3.transform.position = position3;
    }
}
