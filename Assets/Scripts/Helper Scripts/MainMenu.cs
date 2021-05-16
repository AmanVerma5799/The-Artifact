using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas howToPlayCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void HowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    public void BackToMenu()
    {
        howToPlayCanvas.enabled = false;
    }
}
