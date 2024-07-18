using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsOverUI : MonoBehaviour
{
    public bool isOver;
    public bool mouseOver = false;
    public static IsOverUI Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckOverUI();
    }
    public bool getIsOver()
    {
        return isOver;
    }

    public bool getMouseOver()
    {
        return mouseOver;
    }

    private void CheckOverUI()
    {
        isOver = EventSystem.current.IsPointerOverGameObject();
    }

    public void OnMouseEnter()
    {
        mouseOver = true;
    }

    public void OnMouseExit()
    {
        mouseOver = false;
    }

}
