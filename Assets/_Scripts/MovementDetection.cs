using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;

public class MovementDetection : MonoBehaviour
{
    public Text _stepText, _distanceText;
    private Pedometer _pedometer;
    [SerializeField] private EnemyHealth _health;

    private void Start()
    {
         _pedometer = new Pedometer(OnStep);
        OnStep(0, 0);
    }

    private void OnStep(int _steps, double _distance)
    {
        _stepText.text = _steps.ToString();
        _distanceText.text = _distance.ToString();
        _health.DoDamage(_steps/10);
    }

    public void MeterDispose()
    {
        _pedometer.Dispose();
    }

    public void WhenDone()
    {
        _pedometer.Dispose();
    }
}
