using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side : MonoBehaviour
{
    public void showSidepanelTest()
    {
        GameObject sidePanel = GameObject.Find("SidepanelYggdrasil");
        Animator anim = sidePanel.GetComponent<Animator>();
        anim.SetBool("Show", false);
    }
}
