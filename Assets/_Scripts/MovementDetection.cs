using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PedometerU;

public class MovementDetection : MonoBehaviour
{
    private Pedometer _pedometer;

    public UnityEvent OnMovement;
    public Text _stepText, _distanceText;

    private void Start()
    {
         _pedometer = new Pedometer(OnStep);
        OnStep(0, 0);
    }

    private void OnStep(int _steps, double _distance)
    {
        _stepText.text = "Total steps: " + _steps.ToString();
        _distanceText.text = _distance.ToString();
        OnMovement.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnMovement.Invoke();
        }
    }

    public void MeterDispose()
    {
        _pedometer.Dispose();
    }
}
