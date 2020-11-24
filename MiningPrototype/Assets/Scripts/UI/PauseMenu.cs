﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] SceneReference mainMenu;
    [SerializeField] Image darkoverlay;

    [Zenject.Inject] ProgressionHandler progressionHandler;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Unpause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        if (isPaused)
            Unpause();
        else
            Pause();
    }

    public void Pause()
    {
        isPaused = true;

        Time.timeScale = 0f;
        darkoverlay.color = new Color(0,0,0,0.66f);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void Unpause()
    {
        isPaused = false;

        Time.timeScale = progressionHandler.TimeScale;
        darkoverlay.color = new Color(0, 0, 0, 0);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}