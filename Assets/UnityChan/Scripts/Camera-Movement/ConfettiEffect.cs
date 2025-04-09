using UnityEngine;

public class ConfettiEffect : MonoBehaviour
{
    public GameObject confettiPrefab; // The particle system prefab for confetti
    private ParticleSystem confettiSystem; // The actual particle system

    void Start()
    {
        // Instantiate the confetti effect and hide it initially
        if (confettiPrefab != null)
        {
            confettiSystem = Instantiate(confettiPrefab).GetComponent<ParticleSystem>();
            confettiSystem.Stop(); // Stop it initially
            confettiSystem.transform.position = new Vector3(0, 2, 0); // Set the starting position above the screen (or wherever you'd like)
        }
        else
        {
            Debug.LogError("Confetti Prefab is missing!");
        }
    }

    void Update()
    {
        // Detect right mouse click (mouse button 1 is right-click)
        if (Input.GetKeyDown("a")) // Right-click
        {
            StartConfetti();
        }
    }

    void StartConfetti()
    {
        if (confettiSystem != null)
        {
            confettiSystem.Play(); // Play the confetti effect
        }
    }
}
