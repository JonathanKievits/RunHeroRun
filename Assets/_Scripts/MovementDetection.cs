using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;

public class MovementDetection : MonoBehaviour
{
    public Text _stepText, _distanceText;
    [SerializeField]private EnemyHealth _enemyHealth;
    private Pedometer _pedometer;

    private void Start()
    {
        _pedometer = new Pedometer(OnStep);
        OnStep(0, 0);
    }

    private void OnStep(int _steps, double _distance)
    {
        _enemyHealth.DoDamage(_steps);
        _stepText.text = _steps.ToString();
        _distanceText.text = _distance.ToString();
    }

    public void WhenDone()
    {
        _pedometer.Dispose();
    }
}