using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForschungsController : MonoBehaviour
{

    public static ForschungsController instance;
    public bool isAvailable;

    // index für spriterenderer für jeden button on change
    private Image CIRangeColorImage;
    public GameObject CIRangeIcon;


    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            CIRangeColorImage = CIRangeIcon.GetComponent<Image>();

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CIRangeColorImage = CIRangeIcon.GetComponent<Image>();
    }
    // methode für jede research
    public void CalmnessIceRange()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if(isAvailable)
        {
            foreach(Tower researchTower in ForschungSystem.instance.activeTowers)
            {
                researchTower.upgrader.UpgradeRange();
            }
            
            // CIRangeColorImage.color = new Color32(129, 204, 235, 255);
            // broken ???
        }
    }

}
