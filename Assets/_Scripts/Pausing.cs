using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas = null;
    [SerializeField] private Canvas _playCanvas = null;
    [SerializeField] private Button _pButton = null;
    [SerializeField] private Button _cButton = null;

    void Start()
    {
        //Disables the Pausing UI when the script gets executed
        _pauseCanvas.enabled = false;

        Button cancel = _cButton.GetComponent<Button>();
        cancel.onClick.AddListener(Paused);
        Button pause = _pButton.GetComponent<Button>();
        pause.onClick.AddListener(Paused);
    }
    
    private void Paused()
    {
        //Checks if the UI is enabled if so the time/game pauses
        switch (_pauseCanvas.enabled)
        {
            case false:
                _pauseCanvas.enabled = true;
                _playCanvas.enabled = false;
                Time.timeScale = 0;
                break;
            default:
                _pauseCanvas.enabled = false;
                _playCanvas.enabled = true;
                Time.timeScale = 1;
                break;
        }
    }
}
