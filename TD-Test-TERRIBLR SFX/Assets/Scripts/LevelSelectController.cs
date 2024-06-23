using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    public Transform theCam;

    public float moveSpeed;


    public float zoomSpeed;  // Speed of the zoom effect
    public float minZoom, maxZoom;  // Minimum and maximum zoom limits
    public Transform minPos, maxPos;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.musicPlaylist = new string[] { "Ingame_1", "Ingame_2", "Ingame_3" };
        AudioManager.Instance.StartPlaylist();
        AudioManager.Instance.PlayUI("Woosh");
    }

    // Update is called once per frame
    void Update()
    {
        HandleZoom();
        if (Input.GetMouseButton(2))
        {
            HandleCameraMovement();
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            CameraUp();
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            CameraDown();
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            CameraLeft();
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            CameraRight();
        }
    }

    private void HandleCameraMovement()
    {
          Vector2 adjustedMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
         if (adjustedMousePos.x > .75f)
    {
        CameraRight();
    }
    else if (adjustedMousePos.x < .25f)
    {
       CameraLeft();
    }

    if (adjustedMousePos.y > .75f)
    {
       CameraUp();
    }
    else if (adjustedMousePos.y < .25f)
    {
 CameraDown();
    }
    }


    private void CameraLeft()
    {
        if(theCam.position.x > minPos.position.x)
        theCam.position -= theCam.right * moveSpeed * Time.deltaTime;
    }

    private void CameraRight()
    {
        if(theCam.position.x < maxPos.position.x)
        theCam.position += theCam.right * moveSpeed * Time.deltaTime;
    }

    private void CameraUp()
    {
        if(theCam.position.z < minPos.position.z)
        theCam.position += theCam.forward * moveSpeed * Time.deltaTime;
    }

    private void CameraDown()
    {
        if(theCam.position.z > maxPos.position.z)
        theCam.position -= theCam.forward * moveSpeed * Time.deltaTime;

    }

    private void HandleZoom()
    {
        Vector3 pos = theCam.position;
        if (pos.y > minZoom)
        {
            pos.y -= Input.mouseScrollDelta.y * 1;
            theCam.position = pos;
        }
        else
        {
            pos.y = minZoom;
            theCam.position = pos;
        }

        if (pos.y < maxZoom)
        {
            pos.y -= Input.mouseScrollDelta.y * 1;
            theCam.position = pos;
        }
        else
        {
            pos.y = maxZoom;
            theCam.position = pos;
        }

    }
}
