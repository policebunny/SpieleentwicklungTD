using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForschungsController : MonoBehaviour
{

    public static ForschungsController instance;
    public Builder bob;
    public bool isAvailable;

    // index f�r spriterenderer f�r jeden button on change
    // private Image CIRangeColorImage;
    // public GameObject CIRangeIcon;

    public int[] discovered = new int[6];
    public Button[] disabled = new Button[6];


    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            // CIRangeColorImage = CIRangeIcon.GetComponent<Image>();

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        discovered = new int[6];
        for(int i = 0; i < discovered.Length; i++)
        {
            discovered[i] = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // CIRangeColorImage = CIRangeIcon.GetComponent<Image>();
    }

    public int[] getdiscovered()
    {
        return discovered;
    }

    public bool checkIfdiscovered(int whichResearch)
    {
        bool isDiscovered = false;
        if (discovered[whichResearch] != 0)
        {
            isDiscovered = true;
        }
        return isDiscovered;
    }

    public void ApplySpecificResearch(int whatToApply)
    {
        switch(whatToApply)
        {
            case 0:
                // case Movementspeed
                bob.UpgradeMovement();

                break;
            case 1:
                // case Movementspeed
                bob.UpgradeMovement();
                
                break;
            case 2:
                // case Movementspeed
                bob.UpgradeMovement();

                break;
            case 3:
                // case Buildspeed
                bob.UpgradeBuildtime();
                break;
            case 4:
                // case Buildspeed
                bob.UpgradeBuildtime();

                break;
            case 5:
                // case Buildspeed
                bob.UpgradeBuildtime();
                break;
            default:
                break;
        }
    }

    // methode f�r jede research

    public void researchMovement0()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if(isAvailable)
        {
            if(!checkIfdiscovered(0))
            {
                bob.UpgradeMovement();
                discovered[0] = 1;
                disabled[0].interactable = false;
            } else
            {
                ForschungSystem.instance.addSkillpoint();
                
            }
        }
    }

    public void researchMovement1()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(1))
            {
                bob.UpgradeMovement();
                discovered[1] = 1;
                disabled[1].interactable = false;
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
        }
    }

    public void researchMovement2()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(2))
            {
                bob.UpgradeMovement();
                discovered[2] = 1;
                disabled[2].interactable = false;
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
        }
    }

    public void researchBuildtime3()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(3))
            {
                bob.UpgradeBuildtime();
                discovered[3] = 1;
                disabled[3].interactable = false;
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
        }
    }

    public void researchBuildtime4()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(4))
            {
                bob.UpgradeBuildtime();
                discovered[4] = 1;
                disabled[4].interactable = false;
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
        }
    }

    public void researchBuildtime5()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(5))
            {
                bob.UpgradeBuildtime();
                discovered[5] = 1;
                disabled[5].interactable = false;
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
        }
    }

}
