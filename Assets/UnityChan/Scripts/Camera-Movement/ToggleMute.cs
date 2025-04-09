using UnityEngine;

public class ToggleMute : MonoBehaviour
{
    private bool isMuted = false; // Tracks the mute state

    void Update()
    {
        // Check if the "O" key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleMuteAudio();
        }
    }

    void ToggleMuteAudio()
    {
        isMuted = !isMuted; // Toggle the mute state

        // Set the global audio volume
        AudioListener.volume = isMuted ? 0f : 1f;

        // Log the mute state (optional)
        Debug.Log(isMuted ? "Audio is muted" : "Audio is unmuted");
    }
}
