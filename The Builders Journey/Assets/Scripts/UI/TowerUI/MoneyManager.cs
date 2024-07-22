using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    public int currentMoney;

    private void Awake()
    {
        // Singleton Pattern: Ensuring only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // If you need periodic updates or checks, place them here
    }

    public void GiveMoney(int amountToGive)
    {
        currentMoney += amountToGive;
        UpdateUI();
    }

    public bool SpendMoney(int amountToSpend)
    {
        if (amountToSpend <= currentMoney)
        {
            currentMoney -= amountToSpend;
            Debug.Log("Spent " + amountToSpend);
            UpdateUI();
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        if (UIController.instance != null && UIController.instance.goldText != null)
        {
            UIController.instance.goldText.text = currentMoney.ToString();
        }

        if (UIControllerNew.instance != null && UIControllerNew.instance.boneText != null)
        {
            UIControllerNew.instance.boneText.text = currentMoney.ToString();
        }
    }
}
