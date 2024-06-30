using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForschungsController : MonoBehaviour
{

    public static ForschungsController instance;
    public Builder bob;
    public bool isAvailable;

    // index für spriterenderer für jeden button on change
    // private Image CIRangeColorImage;
    // public GameObject CIRangeIcon;

    public int[] discovered = new int[6];


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

    // methode für jede research

    public void researchMovement0()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if(isAvailable)
        {
            if(!checkIfdiscovered(0))
            {
                bob.UpgradeMovement();
                discovered[0] = 1;
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
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
        }
    }

    /*
    public void CalmnessIceRange()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if(isAvailable)
        {
            if(!checkIfdiscovered(0))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    researchTower.upgrader.UpgradeRange();
                }
                discovered[0] = 1; // gesetzt als discovered 
            } else
            {
                ForschungSystem.instance.addSkillpoint();
            }


        }
    }

    public void CalmnessIceShattered()
    {
        // frozen enemies recieve more damage, as their defense is pierced
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(1))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discovered[1] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }


        }
    }

    public void CalmnessIceSpiked()
    {
        // frozen enemies are spiked and passing enemies recieve damage
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(2))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discovered[2] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }

        }
    }

    public void CalmnessTickSpeed()
    {
        // ??? Available twice
        // is basically Attackspeed
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(3))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    researchTower.upgrader.UpgradeFireRate();
                }
                discovered[3] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
            

        }
    }

    public void CalmnessIce()
    {
        // freezes all enemies in range
        // old AOE slow tower
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(4))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discovered[4] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
            

        }
    }

    public void CalmnessWater()
    {
        // instead of slowing aura, the tower has knockback
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(5))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discovered[5] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
            

        }
    }

    public void CalmnessWaterAttackspeed()
    {
        // attackspeed
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(6))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    researchTower.upgrader.UpgradeFireRate();
                }
                discovered[6] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }
            
        }
    }

    public void CalmnessWaterWhirlpool()
    {
        // water attacks create a vortex ???
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(7))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // to do
                }
                discovered[7] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }

        }
    }

    public void CalmnessWaterPiercingchill()
    {
        // water attacks are piercing(more dmg), to all in their path??
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(8))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // to do
                }
                discovered[8] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }            

        }
    }

    public void CalmnessWaterKnockbackrange()
    {
        // knockback is higher
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfdiscovered(9))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // to do
                }
                discovered[9] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }          

        }
    }
    */
}
