using UnityEngine;

public class MyClickableObject : MonoBehaviour
{
        public int level = 0;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from camera to mouse position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Cast the ray and check for collision
            {
                if (hit.collider.gameObject == gameObject) // Check if the clicked object is this game object
                {
                    Debug.Log("Object Clicked!");
                    onClick();
                }
            }
        }
    }
    void onClick()
    {
        int x = (int)this.transform.localPosition.x + (40 - 1) / 2;
        int y = (int)this.transform.localPosition.z + (40 - 1) / 2;
        Debug.Log("tile" + y + " " + x);
        level++;
        if (level > 3) {
            level = 0;
        }
    switch (level)  {  
        case 0:
            GetComponent<Renderer>().material.color = Color.white;
            break;
        case 1: 
            GetComponent<Renderer>().material.color = Color.green;
            break;
        case 2: 
            GetComponent<Renderer>().material.color = Color.yellow;
            break;
        case 3:
            GetComponent<Renderer>().material.color = Color.red;
            break;
        default:
            GetComponent<Renderer>().material.color = Color.white;
            break;
        }
    }
}
