using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForschungsController : MonoBehaviour
{

    public static ForschungsController instance;
    public bool isAvailable;

    // index für spriterenderer für jeden button on change
    // private Image CIRangeColorImage;
    // public GameObject CIRangeIcon;

    public int[] discoveredCalm = new int[12];


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
        discoveredCalm = new int[12];
        for(int i = 0; i < discoveredCalm.Length; i++)
        {
            discoveredCalm[i] = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // CIRangeColorImage = CIRangeIcon.GetComponent<Image>();
    }

    public int[] getDiscoveredCalm()
    {
        return discoveredCalm;
    }

    public bool checkIfDiscoveredCalm(int whichResearch)
    {
        bool isDiscovered = false;
        if (discoveredCalm[whichResearch] != 0)
        {
            isDiscovered = true;
        }
        return isDiscovered;
    }

    public void ApplySpecificResearch(Tower toApply, int whatToApply)
    {
        switch(whatToApply)
        {
            case 0:
                // case CalmnessIceRange
                toApply.upgrader.UpgradeRange();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                // tickspeed == attackspeed
                toApply.upgrader.UpgradeFireRate();
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                // attackspeed == tickspeed
                toApply.upgrader.UpgradeFireRate();
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            default:
                break;
        }
    }

    // methode für jede research
    public void CalmnessIceRange()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if(isAvailable)
        {
            if(!checkIfDiscoveredCalm(0))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    researchTower.upgrader.UpgradeRange();
                }
                discoveredCalm[0] = 1; // gesetzt als discovered 
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
            if (!checkIfDiscoveredCalm(1))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discoveredCalm[1] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(2))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discoveredCalm[2] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(3))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    researchTower.upgrader.UpgradeFireRate();
                }
                discoveredCalm[3] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(4))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discoveredCalm[4] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(5))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
                }
                discoveredCalm[5] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(6))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    researchTower.upgrader.UpgradeFireRate();
                }
                discoveredCalm[6] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(7))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // to do
                }
                discoveredCalm[7] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(8))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // to do
                }
                discoveredCalm[8] = 1; // gesetzt als discovered
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
            if (!checkIfDiscoveredCalm(9))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // to do
                }
                discoveredCalm[9] = 1; // gesetzt als discovered
            }
            else
            {
                ForschungSystem.instance.addSkillpoint();
            }          

        }
    }
}
