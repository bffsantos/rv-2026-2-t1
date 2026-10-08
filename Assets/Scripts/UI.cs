using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI healthValueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void UpdateHealth(float health)
    {
        healthValueText.text = health.ToString();
    }
}
