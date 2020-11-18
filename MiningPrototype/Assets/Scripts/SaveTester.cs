﻿using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
            Save();
        else if (Input.GetKeyDown(KeyCode.F5))
            Load();
    }

    [Button(null, EButtonEnableMode.Playmode)]
    public void Save()
    {
        SaveHandler.Save();
    }

    [Button(null, EButtonEnableMode.Playmode)]
    public void Load()
    {
        SaveHandler.Load();
    }

}