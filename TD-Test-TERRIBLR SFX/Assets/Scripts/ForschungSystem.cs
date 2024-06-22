using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ForschungSystem : MonoBehaviour
{
    public static ForschungSystem instance;
    public int CurrentXP = 0; // is magic points
    public int CurrentLvl = 1;
    public int Skillpoints = 1;
    public int Threshold = 50;
    public List<Tower> activeTowers = new List<Tower>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        // UIControllerNew.instance.skillPointsText.text = Skillpoints.ToString();
    }

    public void GetXP(int amountOfXP)
    {
        CurrentXP += amountOfXP;
        checkLvlUp();

        UIControllerNew.instance.magicText.text = CurrentXP.ToString();
    }

    public void addSkillpoint ()
    {
        Skillpoints++;

        foreach (TMP_Text skillPoint in UIControllerNew.instance.skillPointsList)
        {
            skillPoint.text = Skillpoints.ToString();
        }
    }

    public bool removeSkillpoint()
    {
        Skillpoints--;
        if(Skillpoints < 0)
        {
            Skillpoints = 0;
            return false; // not enough skill
        }

        foreach (TMP_Text skillPoint in UIControllerNew.instance.skillPointsList)
        {
            skillPoint.text = Skillpoints.ToString();
        }
        return true; // successfull research
    }

    public void checkLvlUp ()
    {
        if (CurrentXP >= Threshold)
        {
            CurrentLvl++;
            addSkillpoint();
            Threshold += Threshold;

            foreach (TMP_Text LvL in UIControllerNew.instance.lvlTextList)
            {
                LvL.text = CurrentLvl.ToString();
            }

            CurrentXP = 0;
            UIControllerNew.instance.magicText.text = CurrentXP.ToString();
        }
    }

    public void AddActiveTower(Tower newTower)
    {
        activeTowers.Add(newTower);
    }

    public void RemoveActiveTower(Tower toRemove)
    {
        activeTowers.Remove(toRemove);
    }

    public void ResetList()
    {
        activeTowers.Clear();
    }

    public int returnCurrentXP()
    {
        return CurrentXP;
    }

    public int returnCurrentLvl()
    {
        return CurrentLvl;
    }

    public int returnSkill()
    {
        return Skillpoints;
    }
}
