using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI healthValueText;

    public AudioSource audioSource;
    public AudioClip backgorundMusic;

    private void Start()
    {
        audioSource.PlayOneShot(backgorundMusic);
    }

    public void UpdateHealth(float health)
    {
        healthValueText.text = health.ToString();
    }
}
