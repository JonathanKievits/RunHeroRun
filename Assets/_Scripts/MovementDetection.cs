﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;

public class MovementDetection : MonoBehaviour
{
    public Text _stepText, _distanceText;
    private Pedometer _pedometer;

    private void Start()
    {
         _pedometer = new Pedometer(OnStep);
        OnStep(0, 0);
    }

    private void OnStep(int _steps, double _distance)
    {
        _stepText.text = _steps.ToString();
        _distanceText.text = _distance.ToString();
    }
}