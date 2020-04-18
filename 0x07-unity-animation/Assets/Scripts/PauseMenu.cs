using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject PausedCanvas; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        PausedCanvas.SetActive(true);
        paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PausedCanvas.SetActive(false);
        paused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }

    public void Options()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("Previous", SceneManager.GetActiveScene().name);
        Resume();
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }
}