using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BringPause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    public string titleScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }
    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(titleScreen);
    }
}
