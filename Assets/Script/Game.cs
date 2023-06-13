using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float maxTimeLimit = 60f;
    private float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //public GameObject text;
    public Text timeText; // Reference to a UI text element

    void Update()
    {
        // Increment the elapsed time by the time passed since the last frame
        elapsedTime += Time.deltaTime;

        // Calculate remaining time
        float remainingTime = maxTimeLimit - elapsedTime;

        string formattedTime = FormatTime(remainingTime);

        // Update the UI text element with the remaining time
        timeText.text = formattedTime;

        // // Check if the time limit has been reached
        // if (elapsedTime >= maxTimeLimit)
        // {
        //     // Time limit reached, take appropriate action (e.g., end the game)
        //     EndGame();
        // }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
