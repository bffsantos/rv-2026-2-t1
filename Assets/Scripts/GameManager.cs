using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;

    private static GameManager _Instance;

    public static GameManager Instance
    {
        get
        {
            if( _Instance == null )
            {
                _Instance = Instantiate(Resources.Load<GameManager>(typeof(GameManager).FullName));
            }
            return _Instance;
        }
    }

    public void Awake()
    {
        if(_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Instance = this;
        }
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Menu");
        }

    }

    public void GameOver()
    {
        gameOver = true;
    }
}
