using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 0.5f;
    private Vector3 dragOrigin;
    public Transform character;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = Input.mousePosition - dragOrigin;
            Vector3 movement = new Vector3(-difference.x, -difference.y, 0) * dragSpeed * Time.deltaTime;

            transform.Translate(movement, Space.Self);

            dragOrigin = Input.mousePosition;
        }

        // Stop dragging when the middle mouse button is released
        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
        }

        // re-center the camera on the character when the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDragging = false;

        }


    }

}
