using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimationController : MonoBehaviour
{
    public float fadeTime = 1f;

    public CanvasGroup[] canvasGroups;

    public RectTransform[] rects;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public void PanelAsgard()
    {
        PanelFadeOut();
        canvasGroup = canvasGroups[0];
        rectTransform = rects[0];
        PanelFadeIn();
    }

     public void PanelAlfheim()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[1];
        rectTransform = rects[1];
        PanelFadeIn();
    }

     public void PanelMuspellheim()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[2];
        rectTransform = rects[2];
        PanelFadeIn();
    }

     public void PanelMidgard()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[3];
        rectTransform = rects[3];
        PanelFadeIn();
    }
    public void PanelVanaheim()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[4];
        rectTransform = rects[4];
        PanelFadeIn();
    }

    public void PanelNidavellir()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[5];
        rectTransform = rects[5];
        PanelFadeIn();
    }

    public void PanelJotunheim()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[6];
        rectTransform = rects[6];
        PanelFadeIn();
    }

    public void PanelNilfheim()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[7];
        rectTransform = rects[7];
        PanelFadeIn();
    }

    public void PanelHelmheim()
     {
        PanelFadeOut();
        canvasGroup = canvasGroups[8];
        rectTransform = rects[8];
        PanelFadeIn();
    }

    

     void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(1237f, 10f, 0f);
        rectTransform.DOAnchorPos(new Vector2(630f, 10f), fadeTime,false);
        canvasGroup.DOFade(1, fadeTime);
    }    
     void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(630f, 10f, 0f);
        rectTransform.DOAnchorPos(new Vector2(1237f, 10f), fadeTime,false);
        canvasGroup.DOFade(0, fadeTime);
    }
}
