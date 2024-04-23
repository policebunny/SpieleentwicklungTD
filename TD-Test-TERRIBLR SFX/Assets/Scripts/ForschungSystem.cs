using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForschungSystem : MonoBehaviour
{
    public static ForschungSystem instance;
    public int CurrentXP = 0;
    public int CurrentLvl = 1;
    public int Skillpoints = 1;
    public int Threshold = 100;
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
    }

    public void addSkillpoint ()
    {
        Skillpoints++;
    }

    public void removeSkillpoint()
    {
        Skillpoints--;
    }

    public void checkLvlUp ()
    {
        if (CurrentXP >= Threshold)
        {
            CurrentLvl++;
            addSkillpoint();
            Threshold += Threshold;
            // maybe add here lvl up sound?
        }
    }
}
