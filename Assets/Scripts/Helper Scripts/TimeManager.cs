using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text timerText;

    public float timeToWin = 300;

    private bool gameover;

    private GameObject artifact;

    private StringBuilder stringBuilder;

    private void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        stringBuilder = new StringBuilder();
    }

    private void Update()
    {
        if(gameover || !artifact)
        {
            return;
        }

        timeToWin -= Time.deltaTime;
        
        if(timeToWin <= 0)
        {
            timeToWin = 0;
            gameover = true;

            Destroy(artifact);

            GameOverUI.instance.GameOver("You Win!");
        }

        DisplayTime((int)timeToWin);
    }

    void DisplayTime(int time)
    {
        stringBuilder.Length = 0;
        stringBuilder.Append("Time Remaining : ");
        stringBuilder.Append(time);

        timerText.text = stringBuilder.ToString();
    }
}
