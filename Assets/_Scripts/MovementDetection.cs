using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;

public class MovementDetection : MonoBehaviour
{
    private Pedometer _pedometer;
    private int _damage = 1;
    [SerializeField] private EnemyHealth _health = null;

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
        _health.DoDamage(_damage);
    }

    public void MeterDispose()
    {
        _pedometer.Dispose();
    }
}
