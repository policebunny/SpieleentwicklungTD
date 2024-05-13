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
        AudioManager.instance.PlayLevelSelectMusic();
    }

    // Update is called once per frame
    void Update()
    {
        HandleZoom();
        if(Input.GetMouseButton(1))
        {
        
        Vector2 adjustedMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);


        if (adjustedMousePos.x > .75f)
        {
            if (adjustedMousePos.x > .9f)
            {
                theCam.position += theCam.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                theCam.position += theCam.right * moveSpeed * Time.deltaTime * .5f;
            }
        }

        if (adjustedMousePos.x < .25f)
        {
            if (adjustedMousePos.x < .1f)
            {
                theCam.position -= theCam.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                theCam.position -= theCam.right * moveSpeed * Time.deltaTime * .5f;
            }
        }

        if (adjustedMousePos.y > .75f)
        {
            if (adjustedMousePos.y > .9f)
            {
                theCam.position += theCam.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                theCam.position += theCam.forward * moveSpeed * Time.deltaTime * .5f;
            }
        }

        if (adjustedMousePos.y < .25f)
        {
            if (adjustedMousePos.y < .1f)
            {
                theCam.position -= theCam.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                theCam.position -= theCam.forward * moveSpeed * Time.deltaTime * .5f;
            }
        }
        }
        //theCam.position = new Vector3(Mathf.Clamp(theCam.position.x, minPos.position.x, maxPos.position.x), theCam.position.y, Mathf.Clamp(theCam.position.z, minPos.position.z, maxPos.position.z));
    }

      private void HandleZoom()
    {
        Vector3 pos = theCam.position;
        pos.y -= Input.mouseScrollDelta.y * 1;
        theCam.position = pos;
    }
}
