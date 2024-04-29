using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForschungSystemLoader : MonoBehaviour
{
    public ForschungSystem theFS;

    private void Awake()
    {
        if (FindObjectOfType<ForschungSystem>() == null)
        {
            ForschungSystem.instance = Instantiate(theFS);
            DontDestroyOnLoad(ForschungSystem.instance.gameObject);
        }
    }
}
