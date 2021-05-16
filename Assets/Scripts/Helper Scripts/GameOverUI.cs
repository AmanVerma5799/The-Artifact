using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    [SerializeField] private Canvas gameoverCanvas;
    [SerializeField] private Text gameoverText;
    [SerializeField] private GameObject enemySpawner;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOver(string gameOverInfo)
    {
        gameoverText.text = gameOverInfo;
        gameoverCanvas.enabled = true;

        Destroy(enemySpawner);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
