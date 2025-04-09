using UnityEngine;

public class CharacterMouseMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;

        // Update position based on mouse movement
        Vector3 newPosition = transform.position;
        newPosition.x -= mouseX; // Move left/right
        newPosition.y += mouseY; // Move forward/backward
        transform.position = newPosition;
    }
}
