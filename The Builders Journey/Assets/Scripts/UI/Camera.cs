using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.unscaledDeltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.unscaledDeltaTime;

        transform.Translate(horizontal, vertical, 0);
    }
}
