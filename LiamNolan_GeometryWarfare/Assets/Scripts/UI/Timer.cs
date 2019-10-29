using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText, difficulty;
    private float timer;

    public void StartTimer()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        timerText.text = string.Format("{0}:{1}", minutes, seconds);

        difficulty.text = DifficultyText(Mathf.Floor(timer / 60));
    }

    private string DifficultyText(float f)
    {
        if (f < 2) return "very easy";
        if (f < 4) return "easy";
        if (f < 8) return "medium";
        if (f < 12) return "hard";
        if (f < 16) return "very hard";
        if (f < 20) return "impossible";
        return "f";
    }

    public int GetMinutes()
    {
        return (int)Mathf.Floor(timer / 60);
    }
}
