﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle ready;

    private void Start()
    {
        if (PlayerPrefs.GetString("IsInverted") != "")
            if (bool.Parse(PlayerPrefs.GetString("IsInverted")) != ready.isOn)
                ready.isOn = bool.Parse(PlayerPrefs.GetString("IsInverted"));
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Previous"));
    }

    public void Apply()
    {
        PlayerPrefs.SetString("IsInverted", ready.isOn.ToString());
    }
}
