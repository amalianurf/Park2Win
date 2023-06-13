using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject guideButton;
    public GameObject pauseButton;

    public void quitGame()
    {
        Application.Quit();
    }

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void panelButton()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        guideButton.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void resumeButton()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
        guideButton.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void howToPlayButton()
    {
        panel.SetActive(true);
    }

    public void backButton()
    {
        panel.SetActive(false);
    }

}
