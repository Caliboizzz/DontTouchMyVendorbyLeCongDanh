using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlRestart : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject PausePanel;

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Scene restarted");
        Time.timeScale = 1f;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
    }


}
