using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForschungSystem : MonoBehaviour
{
    public static ForschungSystem instance;
    public int CurrentXP = 0; // is magic points
    public int CurrentLvl = 1;
    public int Skillpoints = 1;
    public int Threshold = 50;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetXP(int amountOfXP)
    {
        CurrentXP += amountOfXP;
        checkLvlUp();
        // UIController.instance.goldText.text = currentMoney.ToString();
        // change to currentXP.ToString(); fitting to UI object
    }

    public void addSkillpoint ()
    {
        Skillpoints++;
        // UIController.instance.goldText.text = currentMoney.ToString();
        // change to Skillpoints.ToString(); fitting to UI object
    }

    public void removeSkillpoint()
    {
        Skillpoints--;
        // UIController.instance.goldText.text = currentMoney.ToString();
        // change to Skillpoints.ToString(); fitting to UI object
    }

    public void checkLvlUp ()
    {
        if (CurrentXP >= Threshold)
        {
            CurrentLvl++;
            addSkillpoint();
            Threshold += Threshold;
            // UIController.instance.goldText.text = currentMoney.ToString();
            // change to CurrentLvl.ToString(); fitting to UI object

            // maybe add here lvl up sound?

            CurrentXP = 0;
            // UIController.instance.goldText.text = currentMoney.ToString();
            // change to currentXP.ToString(); fitting to UI object
        }
    }
}
