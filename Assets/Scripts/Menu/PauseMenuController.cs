using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject PausePopout;
    public GameObject Background;
    public GameObject SettingsPopoutContainer;
    public GameObject SettingsPopout;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;

        foreach (Transform child in SettingsPopoutContainer.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }

        SettingsPopout.SetActive(false);
        Background.SetActive(false);
        PausePopout.SetActive(false);

        isPaused = false;
    }

    private void Pause()
    {
        Time.timeScale = 0;

        PausePopout.SetActive(true);
        Background.SetActive(true);
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneLoader.LoadMainMenu();
        Time.timeScale = 1;
    }
}
