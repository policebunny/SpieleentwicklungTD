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

    public bool checkIfDiscovered(int whichResearch)
    {
        bool isDiscovered = false;
        if (discoveredCalm[whichResearch] != 0)
        {
            isDiscovered = true;
        }
        return isDiscovered;
    }

    // methode für jede research
    public void CalmnessIceRange()
    {
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if(isAvailable)
        {
            if(!checkIfDiscovered(0))
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
            if (!checkIfDiscovered(1))
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
            if (!checkIfDiscovered(2))
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
        isAvailable = ForschungSystem.instance.removeSkillpoint();
        if (isAvailable)
        {
            if (!checkIfDiscovered(3))
            {
                foreach (Tower researchTower in ForschungSystem.instance.activeTowers)
                {
                    // todo
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
            if (!checkIfDiscovered(4))
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
            if (!checkIfDiscovered(5))
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
            if (!checkIfDiscovered(6))
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
            if (!checkIfDiscovered(7))
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
            if (!checkIfDiscovered(8))
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
            if (!checkIfDiscovered(9))
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
