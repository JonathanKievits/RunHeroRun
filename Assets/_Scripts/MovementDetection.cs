using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PedometerU;

public class MovementDetection : MonoBehaviour
{
    public Text StepText;
    private Pedometer _pedometer;
    private EnemyHealth _enemyHealth = null;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
         _pedometer = new Pedometer(OnStep);
        OnStep(0, 0);
        _enemyHealth.GetComponent<EnemyHealth>();
    }

    private void OnStep(int _steps, double _distance)
    {
        _enemyHealth.DoDamage(_steps);
        StepText.text = (_steps.ToString()) + " " + (_distance.ToString("2F"));
    }

    /*public void WhenDone()
    {
        _pedometer.Dispose();
    }*/
}
