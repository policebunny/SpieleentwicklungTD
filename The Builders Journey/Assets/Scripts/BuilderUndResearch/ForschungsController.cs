using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForschungsController : MonoBehaviour
{

    public static ForschungsController instance;
    public Builder bob;
    public bool isAvailable;

    public bool isSpecific = false;

    // index f�r spriterenderer f�r jeden button on change
    // private Image CIRangeColorImage;
    // public GameObject CIRangeIcon;

    public int[] discovered = new int[6];
    public Button[] disabled = new Button[6];


    private void Awake()
    {

        
    }


    // Start is called before the first frame update
    void Start()
    {
        discovered = ForschungSystem.instance.getDiscovered();
        for (int i = 0; i < discovered.Length; i++)
        {
            if (discovered[i] != 0)
            {
                ApplySpecificResearch(i);
            }
        }
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
                isSpecific = true;
                researchMovement0();
                isSpecific = false;

                break;
            case 1:
                // case Movementspeed
                isSpecific = true;
                researchMovement1();
                isSpecific = false;

                break;
            case 2:
                // case Movementspeed
                isSpecific = true;
                researchMovement2();
                isSpecific = false;

                break;
            case 3:
                // case Buildspeed
                isSpecific = true;
                researchBuildtime3();
                isSpecific = false;
                break;
            case 4:
                // case Buildspeed
                isSpecific = true;
                researchBuildtime4();
                isSpecific = false;

                break;
            case 5:
                // case Buildspeed
                isSpecific = true;
                researchBuildtime5();
                isSpecific = false;
                break;
            default:
                break;
        }
    }

    // methode f�r jede research

    public void researchMovement0()
    {
        if(!isSpecific)
        {
            isAvailable = ForschungSystem.instance.removeSkillpoint();
            if (isAvailable)
            {
                if (!checkIfdiscovered(0))
                {
                    bob.UpgradeMovement();
                    discovered[0] = 1;
                    disabled[0].interactable = false;
                }
                else
                {
                    ForschungSystem.instance.addSkillpoint();

                }
            }
        } else
        {
            bob.UpgradeMovement();
            discovered[0] = 1;
            disabled[0].interactable = false;
        }
        
    }

    public void researchMovement1()
    {
        if (!isSpecific)
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
        else
        {
            bob.UpgradeMovement();
            discovered[1] = 1;
            disabled[1].interactable = false;
        }
    }

    public void researchMovement2()
    {
        if (!isSpecific)
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
        else
        {
            bob.UpgradeMovement();
            discovered[2] = 1;
            disabled[2].interactable = false;
        }
    }

    public void researchBuildtime3()
    {
        if(!isSpecific)
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
        } else
        {
            bob.UpgradeBuildtime();
            discovered[3] = 1;
            disabled[3].interactable = false;
        }
        
    }

    public void researchBuildtime4()
    {
        if (!isSpecific)
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
        else
        {
            bob.UpgradeBuildtime();
            discovered[4] = 1;
            disabled[4].interactable = false;
        }
    }

    public void researchBuildtime5()
    {
        if (!isSpecific)
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
        else
        {
            bob.UpgradeBuildtime();
            discovered[5] = 1;
            disabled[5].interactable = false;
        }
    }

}
