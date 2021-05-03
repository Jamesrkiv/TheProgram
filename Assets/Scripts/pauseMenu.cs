﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pm;

    private FirstPersonLook look;
    private bool menuOpen = false;
    private GameObject perkTrackr;

    // Start is called before the first frame update
    void Start()
    {
        perkTrackr = GameObject.Find("PerkTracker");
        pm.SetActive(false);
        look = GameObject.Find("Player").GetComponent<FirstPersonLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                menuOpen = false;
                Time.timeScale = 1;
                look.isPlaying = true;
                pm.SetActive(false);
                return;
            }
            menuOpen = true;
            Time.timeScale = 0;
            look.isPlaying = false;
            pm.SetActive(true);
        }
    }

    public void exit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        menuOpen = false;
        Time.timeScale = 1;
        pm.SetActive(false);
        Destroy(perkTrackr);
        SceneManager.LoadScene("MainMenu");
    }
}
