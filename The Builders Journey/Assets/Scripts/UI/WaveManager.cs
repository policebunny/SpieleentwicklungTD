using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; } // Singleton Instance
    public Text waveText; // Reference to the UI Text component
    public int waveCounter { get; private set; } = 0; // Wave Counter

    private void Awake()
    {
        // Implement Singleton Pattern to ensure only one instance of WaveManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Falls das waveText nicht im Inspektor zugewiesen wurde, aber bereits in der Szene existiert
        if (waveText == null)
        {
            waveText = GameObject.Find("WaveText").GetComponent<Text>();
        }
        UpdateWaveText();
    }

    public void IncrementWaveCounter()
    {
        waveCounter++;
        UpdateWaveText();
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = waveCounter.ToString(); // Update the text with the current wave counter
        }
    }

    public void SetWaveText(Text textComponent)
    {
        waveText = textComponent;
        UpdateWaveText(); // Ensure the text is updated immediately when set
    }
}
