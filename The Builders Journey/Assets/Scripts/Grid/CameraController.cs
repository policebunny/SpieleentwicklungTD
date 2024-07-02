using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f; // Speed of camera movement with WASD keys
    public float scrollSpeed = 20f; // Speed of zoom
    public Vector2 panLimit = new Vector2(50, 50); // Limits of the camera movement
    public float minY = 10f; // Minimum height of the camera
    public float maxY = 80f; // Maximum height of the camera
    public float edgeScrollSpeed = 20f; // Speed of camera movement when mouse is at screen edge
    public float edgeThreshold = 10f; // Distance from the screen edge to start scrolling
    public Vector3 initialPosition = new Vector3(0, 40, 0); // Initial position of the camera

    private Vector3 basePosition;

    void Start()
    {
        // Start the camera at the initial position
        basePosition = initialPosition;
        transform.position = initialPosition;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // Move camera with WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        // Move camera by moving mouse to screen edges
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x >= Screen.width - edgeThreshold)
        {
            pos.x += edgeScrollSpeed * Time.deltaTime;
        }
        if (mousePos.x <= edgeThreshold)
        {
            pos.x -= edgeScrollSpeed * Time.deltaTime;
        }
        if (mousePos.y >= Screen.height - edgeThreshold)
        {
            pos.z += edgeScrollSpeed * Time.deltaTime;
        }
        if (mousePos.y <= edgeThreshold)
        {
            pos.z -= edgeScrollSpeed * Time.deltaTime;
        }

        // Zoom in and out with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        // Clamp camera position to pan limits relative to base position
        pos.x = Mathf.Clamp(pos.x, basePosition.x - panLimit.x, basePosition.x + panLimit.x);
        pos.z = Mathf.Clamp(pos.z, basePosition.z - panLimit.y, basePosition.z + panLimit.y);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
