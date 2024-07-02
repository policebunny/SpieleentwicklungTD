using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ControllerHelper : MonoBehaviour
{
    public static UI_ControllerHelper instance;

    public List<GameObject> SidepanelGreen = new List<GameObject>();
    public List<GameObject> SidepanelBlue = new List<GameObject>();
    public List<GameObject> SidepanelRed = new List<GameObject>();
    public List<GameObject> SidepanelYellow = new List<GameObject>();
    public List<GameObject> SidepanelLightblue = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void HideAllPanel()
    {
        foreach (GameObject panel in SidepanelGreen)
        {
            panel.SetActive(false);
        }
        foreach (GameObject panel in SidepanelBlue)
        {
            panel.SetActive(false);
        }
        foreach (GameObject panel in SidepanelRed)
        {
            panel.SetActive(false);
        }
        foreach (GameObject panel in SidepanelYellow)
        {
            panel.SetActive(false);
        }
        foreach (GameObject panel in SidepanelLightblue)
        {
            panel.SetActive(false);
        }
    }

    public void ShowSidepanelDestruction0()
    {
        HideAllPanel();
        SidepanelRed[0].SetActive(true);
    }

    public void ShowSidepanelDestruction1()
    {
        HideAllPanel();
        SidepanelRed[1].SetActive(true);
    }

    public void ShowSidepanelDestruction2()
    {
        HideAllPanel();
        SidepanelRed[2].SetActive(true);
    }

    public void ShowSidepanelDestruction3()
    {
        HideAllPanel();
        SidepanelRed[3].SetActive(true);
    }

    public void ShowSidepanelDestruction4()
    {
        HideAllPanel();
        SidepanelRed[4].SetActive(true);
    }

    public void ShowSidepanelDestruction5()
    {
        HideAllPanel();
        SidepanelRed[5].SetActive(true);
    }
    public void ShowSidepanelDestruction6()
    {
        HideAllPanel();
        SidepanelRed[6].SetActive(true);
    }

    public void ShowSidePanelCommon0()
    {
        HideAllPanel();
        SidepanelBlue[0].SetActive(true);
    }

    public void ShowSidePanelCommon1()
    {
        HideAllPanel();
        SidepanelBlue[1].SetActive(true);
    }

    public void ShowSidePanelCommon2()
    {
        HideAllPanel();
        SidepanelBlue[2].SetActive(true);
    }

    public void ShowSidePanelCommon3()
    {
        HideAllPanel();
        SidepanelBlue[3].SetActive(true);
    }

    public void ShowSidePanelCommon4()
    {
        HideAllPanel();
        SidepanelBlue[4].SetActive(true);
    }

    public void ShowSidePanelCommon5()
    {
        HideAllPanel();
        SidepanelBlue[5].SetActive(true);
    }

    public void ShowSidepanelUpheaval0()
    {
        HideAllPanel();
        SidepanelYellow[0].SetActive(true);
    }

    public void ShowSidepanelUpheaval1()
    {
        HideAllPanel();
        SidepanelYellow[1].SetActive(true);
    }

    public void ShowSidepanelUpheaval2()
    {
        HideAllPanel();
        SidepanelYellow[2].SetActive(true);
    }

    public void ShowSidepanelUpheaval3()
    {
        HideAllPanel();
        SidepanelYellow[3].SetActive(true);
    }

    public void ShowSidepanelUpheaval4()
    {
        HideAllPanel();
        SidepanelYellow[4].SetActive(true);
    }

    public void ShowSidepanelUpheaval5()
    {
        HideAllPanel();
        SidepanelYellow[5].SetActive(true);
    }

    public void ShowSidepanelUpheaval6()
    {
        HideAllPanel();
        SidepanelYellow[6].SetActive(true);
    }

    public void ShowSidepanelHardenedwill0()
    {
        HideAllPanel();
        SidepanelGreen[0].SetActive(true);
    }

    public void ShowSidepanelHardenedwill1()
    {
        HideAllPanel();
        SidepanelGreen[1].SetActive(true);
    }

    public void ShowSidepanelHardenedwill2()
    {
        HideAllPanel();
        SidepanelGreen[2].SetActive(true);
    }

    public void ShowSidepanelHardenedwill3()
    {
        HideAllPanel();
        SidepanelGreen[3].SetActive(true);
    }

    public void ShowSidepanelHardenedwill4()
    {
        HideAllPanel();
        SidepanelGreen[4].SetActive(true);
    }

    public void ShowSidepanelHardenedwill5()
    {
        HideAllPanel();
        SidepanelGreen[5].SetActive(true);
    }

    public void ShowSidepanelHardenedwill6()
    {
        HideAllPanel();
        SidepanelGreen[6].SetActive(true);
    }

    public void ShowSidepanelCalmness0()
    {
        HideAllPanel();
        SidepanelLightblue[0].SetActive(true);
    }

    public void ShowSidepanelCalmness1()
    {
        HideAllPanel();
        SidepanelLightblue[1].SetActive(true);
    }

    public void ShowSidepanelCalmness2()
    {
        HideAllPanel();
        SidepanelLightblue[2].SetActive(true);
    }

    public void ShowSidepanelCalmness3()
    {
        HideAllPanel();
        SidepanelLightblue[3].SetActive(true);
    }

    public void ShowSidepanelCalmness4()
    {
        HideAllPanel();
        SidepanelLightblue[4].SetActive(true);
    }

    public void ShowSidepanelCalmness5()
    {
        HideAllPanel();
        SidepanelLightblue[5].SetActive(true);
    }

    public void ShowSidepanelCalmness6()
    {
        HideAllPanel();
        SidepanelLightblue[6].SetActive(true);
    }

}
